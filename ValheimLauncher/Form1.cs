using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValheimLauncher {
    public partial class Form_Main : Form {
        DataManager dataManager = new DataManager();
        Server? selectedServer;
        LaunchToken launchToken = new LaunchToken();
        LaunchStatus lastKnownStatus = LaunchStatus.DoNothing;
        GlobalKeyboardHook keyboardHook;

        public Form_Main() {
            dataManager.Load();
            InitializeComponent();
            updateUiFromDataManager();
            timer_typePasswordIfNeeded.Enabled = true;
            timer_typePasswordIfNeeded.Start();
            keyboardHook = new GlobalKeyboardHook(new Keys[] { Keys.P });
        }

        private void updateUiFromDataManager(Server? select = null) {
            Util.TryTo("Load data into form", () => {
                var previousIndex = listBox_servers.SelectedIndex;
                listBox_servers.Items.Clear();

                var steamPath = dataManager.SteamPath;
                this.textBox_steam.Text = steamPath;

                var servers = dataManager.Servers;
                foreach (var server in servers) {
                    this.listBox_servers.Items.Add(server);
                }

                if (servers.Count > 0) {
                    this.listBox_servers.ClearSelected();
                    var selectedPrevious = false;
                    if (select != null) {
                        for (int i = 0; i < listBox_servers.Items.Count; i++) {
                            var item = listBox_servers.Items[i] as Server?;
                            if (item?.Id == select.Value.Id) {
                                listBox_servers.SetSelected(i, true);
                                selectedPrevious = true;
                                break;
                            }
                        }
                    }

                    if (!selectedPrevious) {
                        if (previousIndex <= 0) {
                            this.listBox_servers.SetSelected(0, true);
                        }
                        else {
                            var maxIndex = this.listBox_servers.Items.Count;
                            this.listBox_servers.SetSelected(Math.Min(maxIndex, previousIndex), true);
                        }
                    }
                }
            });
        }

        private void listBox_servers_SelectedIndexChanged(object sender, EventArgs e) {
            Util.TryTo("Select server", () => {
                selectedServer = this.listBox_servers.SelectedItem as Server?;
                updateUiFromSelectedServer();
            });
        }

        void updateUiFromSelectedServer() {
            Util.TryTo("Update UI from selected server", () => {
                textBox_host.Text = selectedServer?.HostEndpoint ?? "";
                textBox_password.Text = selectedServer?.Password ?? "";
                button_delete.Visible = selectedServer?.IsFiller == false;
            });
        }

        private void button_save_Click(object sender, EventArgs e) {
            Util.TryTo("Save selected server and steam location", () => {
                dataManager.SteamPath = this.textBox_steam.Text;

                var s = selectedServer.Value;
                var newServer = new Server(textBox_host.Text, textBox_password.Text, isFiller: false);
                if (s.IsFiller) {
                    dataManager.AddServer(newServer);
                }
                else {
                    dataManager.ReplaceServer(selectedServer.Value.Id, newServer);
                }
                dataManager.SaveData();
                updateUiFromDataManager(select: newServer);
            });
        }

        private void button_delete_Click(object sender, EventArgs e) {
            Util.TryTo("Delete server", () => {
                dataManager.RemoveServer(selectedServer.Value.Id);
                dataManager.SaveData();
                updateUiFromDataManager();
            });
        }

        private void button_openGame_Click(object sender, EventArgs e) {
            Util.TryTo("Open game", () => {
                Task.Run(() => {
                    new Launcher().Launch(textBox_steam.Text);
                });
            });
        }

        private void button_openGameAndConnect_Click(object sender, EventArgs e) {
            Util.TryTo("Open game and connect to server", () => {
                Task.Run(() => {
                    new Launcher().Launch(new Server(textBox_host.Text, textBox_password.Text, false), textBox_steam.Text, launchToken);
                });
            });
        }

        private void timer_typePasswordIfNeeded_Tick(object sender, EventArgs e) {
            this.timer_typePasswordIfNeeded.Enabled = false;
            try {
                bool startMonitoring = false;
                switch (lastKnownStatus) {
                    case LaunchStatus.DoNothing:
                        switch (launchToken.Status) {
                            case LaunchStatus.MonitorForP:
                                startMonitoring = true;
                                lastKnownStatus = LaunchStatus.MonitorForP;
                                break;
                        }
                        break;
                }

                if (startMonitoring) {
                    keyboardHook.KeyboardPressed += (s, ev) => {
                        var key = (Keys)ev.KeyboardData.VirtualCode;
                        if (key == Keys.P) {
                            //Type in the password:
                            Util.TryTo("Type in password", () => {
                                for (int i = 0; i < 10; i++) {
                                    SendKeys.SendWait("{BS}");
                                    Thread.Sleep(50);
                                }
                                foreach (var letter in textBox_password.Text) {
                                    SendKeys.SendWait(letter.ToString());
                                    Thread.Sleep(100);
                                }
                                for (int i = 0; i < 3; i++) {
                                    SendKeys.SendWait("{Enter}");
                                    Thread.Sleep(100);
                                }
                                keyboardHook.Dispose();
                                Application.Exit();
                            });
                        }
                    };
                }
            }
            catch (Exception) {
                //We don't display this as it's in the timer and would spam the user.
            }
            finally {
                this.timer_typePasswordIfNeeded.Enabled = true;
            }
        }
    }
}
