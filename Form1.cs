using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_Copy_Paste
{
    public partial class Form1 : Form
    {
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public Form1()
        {
            InitializeComponent();
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                EnterButtons();
            }
        }

        private void EnterButtons()
        {
            Thread.Sleep(Decimal.ToInt32(numericUpDown1.Value*1000));

            IntPtr calcWindow = FindWindow(null, GetActiveWindowTitle());

            if (SetForegroundWindow(calcWindow))
                SendKeys.Send(textBox1.Text);
        }

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EnterButtons();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
