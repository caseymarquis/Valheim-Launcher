using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimServerLauncher {
    class Server {
        public string HostEndpoint;
        public string Password;

        public string HostName => HostEndpoint.Contains(":") ? HostEndpoint.Split(':')[0] : HostEndpoint;
        public int Port => HostEndpoint.Contains(":")? int.Parse(HostEndpoint.Split(':')[1]) : 2456;
    }
}
