using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValheimServerLauncher {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            //STAThread and the below are needed for the keyboard hook
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            var t = new Thread(() => {
                TryTo("Run Application", () => {
                    Run(args);
                });
                Application.Exit();
            });
            t.IsBackground = true;
            t.Start();
            Application.Run();
        }

    }
        
}
