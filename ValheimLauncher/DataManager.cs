using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace ValheimLauncher {
    public class DataManager {
        object lockEverything = new object();
        List<Server> m_servers = new List<Server>();
        string m_steamPath = null;

        /// <summary>
        /// Note that this can return null. It means we're not done loading yet.
        /// Currently we load on the UI thread, so that's not possible.
        /// </summary>
        internal List<Server> Servers {
            get {
                lock (lockEverything) {
                    return m_servers?.ToList();
                }
            }

            set {
                lock (lockEverything) {
                    m_servers = value?.ToList();
                }
            }
        }

        internal string SteamPath {
            get {
                lock (lockEverything) {
                    return m_steamPath;
                }
            }
            set {
                lock (lockEverything) {
                    m_steamPath = value;
                }
            }
        }


        FileInfo configFile => new FileInfo(
            Path.Combine(Environment.GetFolderPath(SpecialFolder.ApplicationData),
                "Valheim-Launcher",
                "server.txt"));

        string initialConfigData => $@"### Servers List ###
#steam={GetStandardSteamLocation()}
IpOrHostName1 Password1
";

        public void Load() {
            Util.TryTo("Load config file", () => {
                var file = this.configFile;
                var configLines = Util.TryTo($"Create or read the servers file at {file.FullName}", () => {
                    if (!file.Exists) {
                        file.Directory.Create();
                        File.WriteAllText(file.FullName, initialConfigData);
                    }
                    return File.ReadAllLines(file.FullName)
                        .Select(x => x.Trim())
                        .Where(x => !string.IsNullOrEmpty(x))
                        .ToArray();
                });

                if (configLines == null) {
                    return;
                }

                var steamLocation = Util.TryTo("Parse steam.exe location", () => {
                    var steamMarker = "#steam=";
                    var steamLine = configLines.FirstOrDefault(x => x.StartsWith(steamMarker));
                    var steamPath = steamLine?.Substring(steamMarker.Length).Trim();
                    if (steamLine != null && File.Exists(steamPath)) {
                        return steamPath;
                    }

                    if (File.Exists(GetStandardSteamLocation())) {
                        return GetStandardSteamLocation();
                    }

                    throw new ApplicationException("Unable to locate steam.exe");
                });

                if (steamLocation == null) {
                    return;
                }
                lock (lockEverything) {
                    m_steamPath = steamLocation;
                }

                var servers = Util.TryTo("Parse server list", () => configLines
                    .Where(x => !x.StartsWith("#") && !string.IsNullOrWhiteSpace(x))
                    .Select(x => {
                        var split = x.Split(' ');
                        var server = split[0];
                        string password = null;
                        if (split.Length > 1) {
                            password = string.Join(" ", split.Skip(1).ToArray());
                        }
                        return new Server(server, password);
                    })
                    .ToList());

                servers.Add(new Server("", "", isFiller: true));

                lock (lockEverything) {
                    m_servers = servers;
                    sortServers();
                }
            });
        }

        internal void RemoveServer(Guid id) {
            lock (lockEverything) {
                m_servers.RemoveAll(x => x.Id == id);
            }
        }

        internal void SaveData() {
            var sb = new StringBuilder();
            sb.AppendLine($"#steam={SteamPath}");
            var servers = this.Servers;
            foreach (var server in servers) {
                if (server.IsFiller) {
                    continue;
                }
                sb.AppendLine($"{server.HostEndpoint} {server.Password}");
            }
            File.WriteAllText(configFile.FullName, sb.ToString());
        }

        internal void AddServer(Server server) {
            ReplaceServer(Guid.NewGuid(), server);
        }

        internal void ReplaceServer(Guid id, Server newValue) {
            lock (lockEverything) {
                m_servers.RemoveAll(x => x.Id == id);
                m_servers.Add(newValue);
                sortServers();
            }
        }

        void sortServers() {
            lock (lockEverything) {
                m_servers = m_servers
                    .OrderBy(x => x.IsFiller)
                    .ThenBy(x => x.HostEndpoint)
                    .ToList();
            }
        }

        string GetStandardSteamLocation() {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Steam", "steam.exe");
        }
    }
}
