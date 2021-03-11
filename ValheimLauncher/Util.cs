using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValheimLauncher {
    static class Util {
        public static void TryTo(string tryingTo, Action doThis) {
            TryTo(tryingTo, () => {
                doThis();
                return 0;
            });
        }

        public static T TryTo<T>(string tryingTo, Func<T> doThis) {
            try {
                return doThis();
            }
            catch (Exception ex) {
                MessageBox.Show($"Failed to '{tryingTo}'", "Error", MessageBoxButtons.OK);
                return default(T);
            }
        }
    }
}
