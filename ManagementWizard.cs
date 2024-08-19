using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ManagementWizard
{
    public partial class ManagementWizard : Form
    {
        public const int NonClientLeftButtonClick = 0xA1;
        public const int ClickOnTitleBar = 0x2;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("User32.dll")]
        public static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public ManagementWizard()
        {
            InitializeComponent();

            string caminhoRelativo = @"Resources\LogoBar.ico";
            string caminhoAbsoluto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, caminhoRelativo);

            BtnClearCache.FlatAppearance.BorderSize = 0;
            BtnClearCache.MouseEnter += BtnClearCache_MouseEnter;
            BtnClearCache.MouseLeave += BtnClearCache_MouseLeave;

            BtnCamIp.FlatAppearance.BorderSize = 0;
            BtnCamIp.MouseEnter += BtnCamIp_MouseEnter;
            BtnCamIp.MouseLeave += BtnCamIp_MouseLeave;

            BtnFenoxConfig.FlatAppearance.BorderSize = 0;
            BtnFenoxConfig.MouseEnter += BtnFenoxConfig_MouseEnter;
            BtnFenoxConfig.MouseLeave += BtnFenoxConfig_MouseLeave;

            IisReset.FlatAppearance.BorderSize = 0;
            IisReset.MouseEnter += IisReset_MouseEnter;
            IisReset.MouseLeave += IisReset_MouseLeave;

            NotifyIcon2.Icon = new Icon(caminhoAbsoluto);
            NotifyIcon2.Visible = true;
            NotifyIcon2.Text = "Management Wizard";

            NotifyIcon2.MouseDoubleClick += notifyIcon2_MouseDoubleClick;
        }

        private void IisReset_MouseEnter1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnCamIp_MouseEnter1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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
                string command = @"ipconfig /flushdns
                                   ipconfig /renew";

                ProcessStartInfo process = new ProcessStartInfo()
                {
                    FileName = "powershell.exe",
                    Arguments = $"/c {command}",
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    CreateNoWindow = false,
                    Verb = "runas"
                };

                using (Process processing = Process.Start(process))
                {
                    processing.WaitForExit();

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
                string script = @"
                    $filePath = 'C:\Program Files (x86)\Fenox V1.0\Fnx64bits.exe.config';
                    $textoNovo = (ipconfig | Select-String -Pattern 'IPv4' | ForEach-Object { $_ -replace '.*:\s*', '' }).Trim();
                    netsh http add iplisten ipaddress=0.0.0.0;
                    netsh http add iplisten $textoNovo;
                    Write-Output 'Endereço IP Capturado.';
                    $conteudo = Get-Content $filePath -Raw;
                    $pattern = '(?<=<endpoint address=""http://)(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})(?=:)';
                    $conteudo = $conteudo -replace $pattern, $textoNovo;
                    Set-Content $filePath $conteudo;
                    Write-Output 'Substituição concluída. Endereços IP atualizados.';
                    ipconfig /renew;
                    ipconfig /flushdns;
                    iisreset;
                ";

                string encodedScript = Convert.ToBase64String(System.Text.Encoding.Unicode.GetBytes(script));

                ProcessStartInfo process = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -EncodedCommand {encodedScript}",
                    Verb = "runas",
                    UseShellExecute = true,
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                using (Process processing = Process.Start(process))
                {
                    processing.WaitForExit();

                    if (processing.ExitCode == 0)
                    {
                        MessageBox.Show("Script executado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao executar o script!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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
                BackColor = Color.FromArgb(255, 1, 66, 117),
            };
            this.Controls.Add(barraTitulo);

            
            barraTitulo.MouseDown += barraTitulo_MouseDown;

            Button btnMinimizar = new Button
            {
                Text = "−",
                ForeColor = Color.White,
                BackColor = Color.FromArgb(255, 1, 66, 117),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(30, 30),
                Dock = DockStyle.Right,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
            };
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.Click += (s, args) => { this.WindowState = FormWindowState.Minimized; };
            barraTitulo.Controls.Add(btnMinimizar);

            Button btnFechar = new Button
            {
                Text = "X",
                ForeColor = Color.Red,
                BackColor = Color.FromArgb(255, 1, 66, 117),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(30, 30),
                Dock = DockStyle.Right,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point)
            };
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.Click += (s, args) => { this.Close(); };
            barraTitulo.Controls.Add(btnFechar);

            PictureBox logoIcon = new PictureBox
            {
                ImageLocation = @"Resources\Fenox-icon.png",
                SizeMode = PictureBoxSizeMode.AutoSize,
                Size = new Size(30, 30),
                Dock = DockStyle.Left
            };
            barraTitulo.Controls.Add(logoIcon);

            
            this.Region = new Region(RoundedRectangle(new Rectangle(0, 0, this.Width, this.Height), 5));

           
            this.Paint += ManagementWizard_Paint;
        }

        private void ManagementWizard_Paint(object sender, PaintEventArgs e)
        {

            int borderWidth = 2;

            using (Pen blackPen = new Pen(Color.DarkGray, borderWidth))
            {
               
                e.Graphics.DrawRectangle(blackPen, new Rectangle(0, 0, this.Width - borderWidth, this.Height - borderWidth));
            }
        }

        private void barraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, NonClientLeftButtonClick, ClickOnTitleBar, 0);
            }
        }

        private GraphicsPath RoundedRectangle(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

             
            path.AddArc(arc, 180, 90);

              
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void BtnClearCache_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null) 
            {
                btn.Size = new Size(btn.Width + 10, btn.Height + 10);
                btn.Location = new Point(btn.Location.X - 5, btn.Location.Y - 5);
                btn.FlatAppearance.BorderSize = 0;
            }
        }

        private void BtnClearCache_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Size = new Size(btn.Width - 10, btn.Height - 10);
                btn.Location = new Point(btn.Location.X + 5, btn.Location.Y + 5);
            }
        }

        private void BtnCamIp_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Size = new Size(btn.Width + 10, btn.Height + 10);
                btn.Location = new Point(btn.Location.X - 5, btn.Location.Y - 5);
                btn.FlatAppearance.BorderSize = 0;
            }
        }

        private void BtnCamIp_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Size = new Size(btn.Width - 10, btn.Height - 10);
                btn.Location = new Point(btn.Location.X + 5, btn.Location.Y + 5);
            }
        }

        private void BtnFenoxConfig_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Size = new Size(btn.Width + 10, btn.Height + 10);
                btn.Location = new Point(btn.Location.X - 5, btn.Location.Y - 5);
                btn.FlatAppearance.BorderSize = 0;
            }
        }

        private void BtnFenoxConfig_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Size = new Size(btn.Width - 10, btn.Height - 10);
                btn.Location = new Point(btn.Location.X + 5, btn.Location.Y + 5);
            }
        }

        private void IisReset_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Size = new Size(btn.Width + 10, btn.Height + 10);
                btn.Location = new Point(btn.Location.X - 5, btn.Location.Y - 5);
                btn.FlatAppearance.BorderSize = 0;
            }
        }

        private void IisReset_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Size = new Size(btn.Width - 10, btn.Height - 10);
                btn.Location = new Point(btn.Location.X + 5, btn.Location.Y + 5);
            }
        }
    }
}
