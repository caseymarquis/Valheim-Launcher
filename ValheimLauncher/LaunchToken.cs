using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValheimLauncher {
    public enum LaunchStatus {
        DoNothing,
        MonitorForP,
    }

    public class LaunchToken {
        object lockEverything = new object();
        LaunchStatus m_status;

        public LaunchStatus Status {
            get{
                lock (lockEverything) {
                    return m_status;
                } 
            }
            set {
                lock (lockEverything) {
                    m_status = value;
                }
            }
        }
    }
}
