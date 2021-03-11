using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimLauncher {
    readonly struct Server {

        public Server(string hostEndpoint, string password, bool isFiller = false) {
            HostEndpoint = hostEndpoint;
            Password = password;
            IsFiller = isFiller;

            Id = Guid.NewGuid();
        }

        public readonly string HostEndpoint;
        public readonly string Password;
        public readonly bool IsFiller;
        public readonly Guid Id;

        public string HostName => HostEndpoint.Contains(":") ? HostEndpoint.Split(':')[0] : HostEndpoint;
        public int Port => HostEndpoint.Contains(":") ? int.Parse(HostEndpoint.Split(':')[1]) : 2456;

        public string DisplayText => IsFiller? "New Server" : $"{HostEndpoint}";
    }
}
