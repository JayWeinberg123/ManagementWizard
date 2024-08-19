namespace ManagementWizard
{
    partial class ManagementWizard
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagementWizard));
            this.NotifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.IisReset = new System.Windows.Forms.Button();
            this.BtnFenoxConfig = new System.Windows.Forms.Button();
            this.BtnClearCache = new System.Windows.Forms.Button();
            this.BtnCamIp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // NotifyIcon2
            // 
            this.NotifyIcon2.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon2.Icon")));
            this.NotifyIcon2.Text = "NotifyIcon2";
            this.NotifyIcon2.Visible = true;
            this.NotifyIcon2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon2_MouseDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(372, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // IisReset
            // 
            this.IisReset.BackgroundImage = global::ManagementWizard.Properties.Resources.ButtonResetIIS;
            this.IisReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.IisReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IisReset.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.IisReset.FlatAppearance.BorderSize = 0;
            this.IisReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.IisReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.IisReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IisReset.Location = new System.Drawing.Point(82, 380);
            this.IisReset.Name = "IisReset";
            this.IisReset.Size = new System.Drawing.Size(242, 56);
            this.IisReset.TabIndex = 3;
            this.IisReset.UseVisualStyleBackColor = true;
            this.IisReset.Click += new System.EventHandler(this.IisReset_Click);
            this.IisReset.MouseEnter += new System.EventHandler(this.IisReset_MouseEnter);
            this.IisReset.MouseLeave += new System.EventHandler(this.IisReset_MouseLeave);
            // 
            // BtnFenoxConfig
            // 
            this.BtnFenoxConfig.BackgroundImage = global::ManagementWizard.Properties.Resources.ButtonIPServer;
            this.BtnFenoxConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnFenoxConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFenoxConfig.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnFenoxConfig.FlatAppearance.BorderSize = 0;
            this.BtnFenoxConfig.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnFenoxConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtnFenoxConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFenoxConfig.Location = new System.Drawing.Point(82, 318);
            this.BtnFenoxConfig.Name = "BtnFenoxConfig";
            this.BtnFenoxConfig.Size = new System.Drawing.Size(242, 56);
            this.BtnFenoxConfig.TabIndex = 2;
            this.BtnFenoxConfig.UseVisualStyleBackColor = true;
            this.BtnFenoxConfig.Click += new System.EventHandler(this.BtnFenoxConfig_Click);
            this.BtnFenoxConfig.MouseEnter += new System.EventHandler(this.BtnFenoxConfig_MouseEnter);
            this.BtnFenoxConfig.MouseLeave += new System.EventHandler(this.BtnFenoxConfig_MouseLeave);
            // 
            // BtnClearCache
            // 
            this.BtnClearCache.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnClearCache.BackgroundImage")));
            this.BtnClearCache.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnClearCache.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClearCache.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnClearCache.FlatAppearance.BorderSize = 0;
            this.BtnClearCache.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnClearCache.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtnClearCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClearCache.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnClearCache.Location = new System.Drawing.Point(82, 194);
            this.BtnClearCache.Name = "BtnClearCache";
            this.BtnClearCache.Size = new System.Drawing.Size(242, 56);
            this.BtnClearCache.TabIndex = 1;
            this.BtnClearCache.UseVisualStyleBackColor = true;
            this.BtnClearCache.Click += new System.EventHandler(this.BtnClearCache_Click);
            this.BtnClearCache.MouseEnter += new System.EventHandler(this.BtnClearCache_MouseEnter);
            this.BtnClearCache.MouseLeave += new System.EventHandler(this.BtnClearCache_MouseLeave);
            // 
            // BtnCamIp
            // 
            this.BtnCamIp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnCamIp.BackgroundImage")));
            this.BtnCamIp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnCamIp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCamIp.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnCamIp.FlatAppearance.BorderSize = 0;
            this.BtnCamIp.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.BtnCamIp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.BtnCamIp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCamIp.Location = new System.Drawing.Point(82, 256);
            this.BtnCamIp.Name = "BtnCamIp";
            this.BtnCamIp.Size = new System.Drawing.Size(242, 56);
            this.BtnCamIp.TabIndex = 0;
            this.BtnCamIp.UseVisualStyleBackColor = true;
            this.BtnCamIp.Click += new System.EventHandler(this.BtnCamIp_Click);
            this.BtnCamIp.MouseEnter += new System.EventHandler(this.BtnCamIp_MouseEnter);
            this.BtnCamIp.MouseLeave += new System.EventHandler(this.BtnCamIp_MouseLeave);
            // 
            // ManagementWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(400, 456);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.IisReset);
            this.Controls.Add(this.BtnFenoxConfig);
            this.Controls.Add(this.BtnClearCache);
            this.Controls.Add(this.BtnCamIp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManagementWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ManagementWizard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button BtnCamIp;
        private System.Windows.Forms.Button BtnClearCache;
        private System.Windows.Forms.Button BtnFenoxConfig;
        private System.Windows.Forms.Button IisReset;
        private System.Windows.Forms.NotifyIcon NotifyIcon2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

