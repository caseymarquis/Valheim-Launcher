
namespace ValheimLauncher {
    partial class Form_Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.listBox_servers = new System.Windows.Forms.ListBox();
            this.groupBox_text = new System.Windows.Forms.GroupBox();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_host = new System.Windows.Forms.TextBox();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.button_openGameAndConnect = new System.Windows.Forms.Button();
            this.button_openGame = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.panel_saveDelete = new System.Windows.Forms.Panel();
            this.panel_middle = new System.Windows.Forms.Panel();
            this.textBox_steam = new System.Windows.Forms.TextBox();
            this.groupBox_hostPassword = new System.Windows.Forms.GroupBox();
            this.groupBox_steamPath = new System.Windows.Forms.GroupBox();
            this.label_pressP = new System.Windows.Forms.Label();
            this.timer_typePasswordIfNeeded = new System.Windows.Forms.Timer(this.components);
            this.groupBox_text.SuspendLayout();
            this.panel_bottom.SuspendLayout();
            this.panel_saveDelete.SuspendLayout();
            this.panel_middle.SuspendLayout();
            this.groupBox_hostPassword.SuspendLayout();
            this.groupBox_steamPath.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_servers
            // 
            this.listBox_servers.DisplayMember = "DisplayText";
            this.listBox_servers.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBox_servers.FormattingEnabled = true;
            this.listBox_servers.Location = new System.Drawing.Point(0, 0);
            this.listBox_servers.Name = "listBox_servers";
            this.listBox_servers.Size = new System.Drawing.Size(441, 56);
            this.listBox_servers.TabIndex = 0;
            this.listBox_servers.SelectedIndexChanged += new System.EventHandler(this.listBox_servers_SelectedIndexChanged);
            // 
            // groupBox_text
            // 
            this.groupBox_text.Controls.Add(this.groupBox_steamPath);
            this.groupBox_text.Controls.Add(this.groupBox_hostPassword);
            this.groupBox_text.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox_text.Location = new System.Drawing.Point(0, 0);
            this.groupBox_text.Name = "groupBox_text";
            this.groupBox_text.Size = new System.Drawing.Size(278, 133);
            this.groupBox_text.TabIndex = 1;
            this.groupBox_text.TabStop = false;
            // 
            // textBox_password
            // 
            this.textBox_password.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_password.Location = new System.Drawing.Point(3, 36);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.PasswordChar = '*';
            this.textBox_password.Size = new System.Drawing.Size(266, 20);
            this.textBox_password.TabIndex = 0;
            // 
            // textBox_host
            // 
            this.textBox_host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_host.Location = new System.Drawing.Point(3, 16);
            this.textBox_host.Name = "textBox_host";
            this.textBox_host.Size = new System.Drawing.Size(266, 20);
            this.textBox_host.TabIndex = 1;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.button_openGameAndConnect);
            this.panel_bottom.Controls.Add(this.button_openGame);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 221);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(441, 36);
            this.panel_bottom.TabIndex = 2;
            // 
            // button_openGameAndConnect
            // 
            this.button_openGameAndConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_openGameAndConnect.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_openGameAndConnect.Location = new System.Drawing.Point(69, 0);
            this.button_openGameAndConnect.Name = "button_openGameAndConnect";
            this.button_openGameAndConnect.Size = new System.Drawing.Size(372, 36);
            this.button_openGameAndConnect.TabIndex = 1;
            this.button_openGameAndConnect.Text = "Open Game and Connect";
            this.button_openGameAndConnect.UseVisualStyleBackColor = true;
            this.button_openGameAndConnect.Click += new System.EventHandler(this.button_openGameAndConnect_Click);
            // 
            // button_openGame
            // 
            this.button_openGame.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_openGame.Location = new System.Drawing.Point(0, 0);
            this.button_openGame.Name = "button_openGame";
            this.button_openGame.Size = new System.Drawing.Size(69, 36);
            this.button_openGame.TabIndex = 0;
            this.button_openGame.Text = "Open Game";
            this.button_openGame.UseVisualStyleBackColor = true;
            this.button_openGame.Click += new System.EventHandler(this.button_openGame_Click);
            // 
            // button_save
            // 
            this.button_save.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_save.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.Location = new System.Drawing.Point(0, 0);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(157, 100);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_delete
            // 
            this.button_delete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_delete.Location = new System.Drawing.Point(0, 100);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(157, 33);
            this.button_delete.TabIndex = 3;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // panel_saveDelete
            // 
            this.panel_saveDelete.Controls.Add(this.button_delete);
            this.panel_saveDelete.Controls.Add(this.button_save);
            this.panel_saveDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_saveDelete.Location = new System.Drawing.Point(284, 0);
            this.panel_saveDelete.Name = "panel_saveDelete";
            this.panel_saveDelete.Size = new System.Drawing.Size(157, 133);
            this.panel_saveDelete.TabIndex = 4;
            // 
            // panel_middle
            // 
            this.panel_middle.Controls.Add(this.panel_saveDelete);
            this.panel_middle.Controls.Add(this.groupBox_text);
            this.panel_middle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_middle.Location = new System.Drawing.Point(0, 56);
            this.panel_middle.Name = "panel_middle";
            this.panel_middle.Size = new System.Drawing.Size(441, 133);
            this.panel_middle.TabIndex = 5;
            // 
            // textBox_steam
            // 
            this.textBox_steam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_steam.Location = new System.Drawing.Point(3, 16);
            this.textBox_steam.Name = "textBox_steam";
            this.textBox_steam.Size = new System.Drawing.Size(266, 20);
            this.textBox_steam.TabIndex = 2;
            // 
            // groupBox_hostPassword
            // 
            this.groupBox_hostPassword.Controls.Add(this.textBox_host);
            this.groupBox_hostPassword.Controls.Add(this.textBox_password);
            this.groupBox_hostPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_hostPassword.Location = new System.Drawing.Point(3, 16);
            this.groupBox_hostPassword.Name = "groupBox_hostPassword";
            this.groupBox_hostPassword.Size = new System.Drawing.Size(272, 59);
            this.groupBox_hostPassword.TabIndex = 3;
            this.groupBox_hostPassword.TabStop = false;
            this.groupBox_hostPassword.Text = "Host/Password";
            // 
            // groupBox_steamPath
            // 
            this.groupBox_steamPath.Controls.Add(this.textBox_steam);
            this.groupBox_steamPath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_steamPath.Location = new System.Drawing.Point(3, 81);
            this.groupBox_steamPath.Name = "groupBox_steamPath";
            this.groupBox_steamPath.Size = new System.Drawing.Size(272, 49);
            this.groupBox_steamPath.TabIndex = 4;
            this.groupBox_steamPath.TabStop = false;
            this.groupBox_steamPath.Text = "Steam Path";
            // 
            // label_pressP
            // 
            this.label_pressP.AutoSize = true;
            this.label_pressP.Location = new System.Drawing.Point(77, 205);
            this.label_pressP.Name = "label_pressP";
            this.label_pressP.Size = new System.Drawing.Size(358, 13);
            this.label_pressP.TabIndex = 6;
            this.label_pressP.Text = "*** Press P in the in-game password form to enter your saved password. ***";
            // 
            // timer_typePasswordIfNeeded
            // 
            this.timer_typePasswordIfNeeded.Tick += new System.EventHandler(this.timer_typePasswordIfNeeded_Tick);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 257);
            this.Controls.Add(this.label_pressP);
            this.Controls.Add(this.panel_middle);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.listBox_servers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Main";
            this.Text = "Valheim Launcher";
            this.groupBox_text.ResumeLayout(false);
            this.panel_bottom.ResumeLayout(false);
            this.panel_saveDelete.ResumeLayout(false);
            this.panel_middle.ResumeLayout(false);
            this.groupBox_hostPassword.ResumeLayout(false);
            this.groupBox_hostPassword.PerformLayout();
            this.groupBox_steamPath.ResumeLayout(false);
            this.groupBox_steamPath.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_servers;
        private System.Windows.Forms.GroupBox groupBox_text;
        private System.Windows.Forms.TextBox textBox_host;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Button button_openGameAndConnect;
        private System.Windows.Forms.Button button_openGame;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Panel panel_saveDelete;
        private System.Windows.Forms.Panel panel_middle;
        private System.Windows.Forms.GroupBox groupBox_hostPassword;
        private System.Windows.Forms.TextBox textBox_steam;
        private System.Windows.Forms.GroupBox groupBox_steamPath;
        private System.Windows.Forms.Label label_pressP;
        private System.Windows.Forms.Timer timer_typePasswordIfNeeded;
    }
}

