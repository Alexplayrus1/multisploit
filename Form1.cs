using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KrnlAPI;

namespace MultiSploit
{
    public partial class Form1 : Form
    {
        KrnlApi krnl = new KrnlApi(); bool AutoAttach = false;
        public Form1()
        {
            InitializeComponent();
            krnl.Initialize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            krnl.Inject();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            krnl.Execute(script.Text);
        }

        private void fps_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            krnl.Execute("setfpscap(140)");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private async void timer1_Tick(object sender, EventArgs e)
            
        {
            {
                if (AutoAttach == false)
                {
                    Process[] rbProcess = Process.GetProcessesByName("RobloxPlayerBeta");
                    if (rbProcess.Length == 1)
                    {
                        if (krnl.IsInjected() == false)
                        {
                            AutoAttach = true;
                            await Task.Delay(5000);
                            krnl.Inject();

                        }
                    }
                }
                if (AutoAttach == true)
                {
                    Process[] rbProcess = Process.GetProcessesByName("RobloxPlayerBeta");
                    if (rbProcess.Length == 0)
                    {
                        if (krnl.IsInjected() == false)
                        {
                            AutoAttach = false;
                        }
                    }
                }
            }
            }

        private void button6_Click_1(object sender, EventArgs e)
        {
            krnl.Execute("loadstring(game:HttpGet('https://raw.githubusercontent.com/EdgeIY/infiniteyield/master/source'))()");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            krnl.Execute("loadstring(game:HttpGet(('https://pastefy.ga/lrjtanrp/raw'),true))()");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            krnl.Execute("loadstring(game:HttpGet('https://the-shed.xyz/roblox/scripts/ChatBypass', true))()");

        }
    }
}
