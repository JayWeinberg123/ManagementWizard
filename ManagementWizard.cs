using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ManagementWizard
{
    public partial class ManagementWizard : Form
    {


        public ManagementWizard()
        {
            InitializeComponent();

            string caminhoRelativo = @"Resources\Fenox-Icon.ico";
            string caminhoAbsoluto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, caminhoRelativo);

            NotifyIcon2.Icon = new Icon(caminhoAbsoluto);
            NotifyIcon2.Visible = true;
            NotifyIcon2.Text = "Management Wizard";

            NotifyIcon2.MouseDoubleClick += notifyIcon2_MouseDoubleClick;
        }

        private void BtnCamIp_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Windows\System32\drivers\etc\hosts";
            string command = $@"Start-Process notepad.exe -ArgumentList '{filePath}' -Verb RunAs";

            ProcessStartInfo process = new ProcessStartInfo
            {
                Verb = "runas",
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process.Start(process);
        }

        private void BtnClearCache_Click(object sender, EventArgs e)
        {
            try
            {

                ProcessStartInfo process = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = "/c ipconfig /flushdns",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = false,
                    Verb = "runas"
                };

                using (Process processing = Process.Start(process))
                {
                    processing.WaitForExit();

                    Thread.Sleep(1000);
                    if (processing.ExitCode == 0)
                    {
                        MessageBox.Show("Limpeza e reconexão feitos com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show("Falha ao tentar limpar o cache e tentar reconexão", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFenoxConfig_Click(object sender, EventArgs e)
        {
            try
            {

                string filePath = @"C:\Program Files (x86)\Fenox V1.0\Fnx64bits.exe.config";

                string command = $@"Start-Process notepad.exe -ArgumentList '{filePath}' -Verb RunAs";

                ProcessStartInfo process = new ProcessStartInfo
                {
                    Verb = "runas",
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{command}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process processing = Process.Start(process))
                {
                    processing.WaitForExit();

                    Thread.Sleep(1000);

                    if (processing.ExitCode == 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Erro ao tentar abrir o arquivo, verifique o mesmo!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IisReset_Click(object sender, EventArgs e)
        {
            try
            {

                ProcessStartInfo process = new ProcessStartInfo()
                {
                    Verb = "runas",
                    FileName = "cmd.exe",
                    Arguments = "/c powershell -Command \"Start-Process iisreset -Verb runAs\"",
                    UseShellExecute = false,
                    CreateNoWindow = false

                };

                using (Process processing = Process.Start(process))
                {
                    processing.WaitForExit();

                    if (processing.ExitCode == 0)
                    {
                        MessageBox.Show("Serviço IIs reiniciado com sucesso", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Verifique a disponibilidade do serviço!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            };
        }

        private void notifyIcon2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            NotifyIcon2.Visible = false;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            NotifyIcon2.Visible = true;
        }

        private void ManagementWizard_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

            Panel barraTitulo = new Panel
            {
                Dock = DockStyle.Top,
                Height = 30,
                BackColor = Color.DodgerBlue,
            };
            this.Controls.Add(barraTitulo);

            Button btnMinimizar = new Button
            {
                Text = "_",
                ForeColor = Color.White,
                BackColor = Color.DodgerBlue,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(30, 30),
                Dock = DockStyle.Right
            };
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.Click += (s, args) => { this.WindowState = FormWindowState.Minimized; };
            barraTitulo.Controls.Add(btnMinimizar);

            Button btnFechar = new Button
            {
                Text = "X",
                ForeColor = Color.Red,
                BackColor = Color.DodgerBlue,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(30, 30),
                Dock = DockStyle.Right
            };
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.Click += (s, args) => { this.Close(); };
            barraTitulo.Controls.Add(btnFechar);
        }
    }
}
