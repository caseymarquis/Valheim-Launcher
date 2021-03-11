using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace ValheimLauncher {
    class Launcher {
        static SemaphoreSlim lockLaunch = new SemaphoreSlim(1, 1);

        public void Launch(string steamPath) {
            Util.TryTo("Launch", () => {
                if (!lockLaunch.Wait(10)) {
                    return;
                }
                try {
                    Process.Start(steamPath, $"-applaunch 892970");
                    Application.Exit();
                }
                finally {
                    lockLaunch.Release();
                }
            });
        }

        public void Launch(Server server, string steamPath, LaunchToken token) {
            if (!lockLaunch.Wait(10)) {
                return;
            }
            try {

                var success = Util.TryTo($"Connect to {server.HostEndpoint}", () => {
                    if (!IPAddress.TryParse(server.HostName, out var ip)) {
                        //User hostname. Must resolve:
                        Util.TryTo($"Resolve IP for {server.HostName}", () => {
                            Console.WriteLine($"Resolving IP Address for {server.HostName}...");
                            var hostEntry = Dns.GetHostEntry(server.HostName);
                            if (!hostEntry.AddressList.Any()) {
                                throw new ApplicationException($"Unable to resolve IP address for: {server.HostName}");
                            }
                            ip = hostEntry.AddressList.First();
                        });
                    }

                    if (ip == null) {
                        return false;
                    }

                    var port = server.Port;
                    //Steam doesn't actually use the password at this point:
                    Process.Start(steamPath, $"-applaunch 892970 +connect {ip.ToString()}:{port} +password {server.Password ?? "NoPassword"}");

                    return true;
                });

                if (!success) {
                    return;
                }

                if (!string.IsNullOrWhiteSpace(server.Password)) {
                    token.Status = LaunchStatus.MonitorForP;
                }
            }
            finally {
                lockLaunch.Release();
            }
        }

    }
}
