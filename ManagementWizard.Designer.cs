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
            this.BtnCamIp = new System.Windows.Forms.Button();
            this.BtnClearCache = new System.Windows.Forms.Button();
            this.BtnFenoxConfig = new System.Windows.Forms.Button();
            this.IisReset = new System.Windows.Forms.Button();
            this.NotifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCamIp
            // 
            this.BtnCamIp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCamIp.Location = new System.Drawing.Point(114, 212);
            this.BtnCamIp.Name = "BtnCamIp";
            this.BtnCamIp.Size = new System.Drawing.Size(161, 44);
            this.BtnCamIp.TabIndex = 0;
            this.BtnCamIp.Text = "Configurar Host";
            this.BtnCamIp.UseVisualStyleBackColor = true;
            this.BtnCamIp.Click += new System.EventHandler(this.BtnCamIp_Click);
            // 
            // BtnClearCache
            // 
            this.BtnClearCache.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClearCache.Location = new System.Drawing.Point(114, 162);
            this.BtnClearCache.Name = "BtnClearCache";
            this.BtnClearCache.Size = new System.Drawing.Size(161, 44);
            this.BtnClearCache.TabIndex = 1;
            this.BtnClearCache.Text = "Limpeza de Cache TCP/IP";
            this.BtnClearCache.UseVisualStyleBackColor = true;
            this.BtnClearCache.Click += new System.EventHandler(this.BtnClearCache_Click);
            // 
            // BtnFenoxConfig
            // 
            this.BtnFenoxConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFenoxConfig.Location = new System.Drawing.Point(114, 262);
            this.BtnFenoxConfig.Name = "BtnFenoxConfig";
            this.BtnFenoxConfig.Size = new System.Drawing.Size(161, 44);
            this.BtnFenoxConfig.TabIndex = 2;
            this.BtnFenoxConfig.Text = "Configurar IP Servidor";
            this.BtnFenoxConfig.UseVisualStyleBackColor = true;
            this.BtnFenoxConfig.Click += new System.EventHandler(this.BtnFenoxConfig_Click);
            // 
            // IisReset
            // 
            this.IisReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IisReset.Location = new System.Drawing.Point(114, 312);
            this.IisReset.Name = "IisReset";
            this.IisReset.Size = new System.Drawing.Size(161, 44);
            this.IisReset.TabIndex = 3;
            this.IisReset.Text = "Reiniciar IIs";
            this.IisReset.UseVisualStyleBackColor = true;
            this.IisReset.Click += new System.EventHandler(this.IisReset_Click);
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
            this.pictureBox1.Location = new System.Drawing.Point(114, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ManagementWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(403, 368);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.IisReset);
            this.Controls.Add(this.BtnFenoxConfig);
            this.Controls.Add(this.BtnClearCache);
            this.Controls.Add(this.BtnCamIp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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

