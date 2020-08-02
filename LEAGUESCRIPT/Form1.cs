using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoItX3Lib;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace LEAGUESCRIPT
{
    public partial class Form1 : Form
    {
        public static IntPtr MWhandle;
        public static IntPtr CWhandle;


        AutoItX3 au3 = new AutoItX3();

        public static string WINDOW_NAME = "League of Legends";

        public static IntPtr handle;


        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string IpClassName, string IpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        public static RECT rect;

        int ooga;

        public int counter;
        public struct RECT
        {
            public int left, top, right, bottom;
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getwindowrectangle();
            au3.WinActivate(WINDOW_NAME);
            au3.MouseMove(rect.left + 120, rect.top + 45, 1);
            au3.MouseClick("LEFT");
            Thread.Sleep(500);
            switch (counter)
            {
                case 1:
                    au3.MouseMove(rect.left + 128, rect.top + 216, 1);
                    au3.MouseClick("LEFT");
                    break;
                case 2:
                    au3.MouseMove(rect.left + 366, rect.top + 223, 1);
                    au3.MouseClick("LEFT");
                    break;
                case 3:
                    au3.MouseMove(rect.left + 625, rect.top + 227, 1);
                    au3.MouseClick("LEFT");
                    break;
                case 4:
                    au3.MouseMove(rect.left + 873, rect.top + 215, 1);
                    au3.MouseClick("LEFT");
                    break;
                default:
                    MessageBox.Show("select a gamemode retard");
                    break;


            }
            Thread.Sleep(500);
            au3.MouseMove(rect.left + 541, rect.top + 688, 1);
            au3.MouseClick("LEFT");
            Thread.Sleep(1500);
            au3.MouseMove(rect.left + 541, rect.top + 688, 1);
            au3.MouseClick("LEFT");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = ColorTranslator.FromHtml("#1E252A");
            CheckForIllegalCrossThreadCalls = false;
            label1.Text = "Welcome : " + Environment.MachineName.ToString() + " !";
            Thread AA = new Thread(autoAccept) { IsBackground = true };
            AA.Start();
            backgroundWorker1.RunWorkerAsync();
        }




        private void autoAccept()
        {
            
            while (true)
            {
                if (checkBox5.Checked )
                {
                    ooga = au3.PixelGetColor(rect.left + 584, rect.top + 555);

                    getwindowrectangle();
                    if (ooga == 0x1E252A)
                    {
                        Thread.Sleep(20);
                        au3.MouseMove(rect.left + 584, rect.top + 555, 1);
                        au3.MouseClick("LEFT");
                        Thread.Sleep(10);
                        au3.MouseClick("LEFT");
                        Thread.Sleep(5000);
                    }
                    
                }
                Thread.Sleep(20);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                counter = 1;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                counter = 2;
            }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                counter = 3;
            }

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                counter = 4;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            getwindowrectangle();
            au3.MouseMove(rect.left + 584, rect.top + 555, 0);
        }

        void getwindowrectangle()
        {
            handle = FindWindow(null, WINDOW_NAME);
            GetWindowRect(handle, out rect);
        }
        bool isGameActive()
        {
            MWhandle = FindWindow(null, "League of Legends");
            CWhandle = GetForegroundWindow();
            return MWhandle == CWhandle ? true : false;
        }

            private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (GetAsyncKeyState(Keys.F1) < 0)
                {
                    checkBox5.Checked = true;

                }
                else if (GetAsyncKeyState(Keys.F2) < 0)
                {
                    checkBox5.Checked = false;
                }
                Thread.Sleep(1);
            }
        }
    }
}
