using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WriteLine("Starting...");
            WindowState = FormWindowState.Minimized;
            Hide();
            //this.Visible = false;
            IsVisibilityChangeAllowed = true;

        }

        public bool IsVisibilityChangeAllowed { get; set; }

        public void WriteLine(String text)
        {
            if (InvokeRequired)
                BeginInvoke((Action<string>)WriteLine, text);
            else
                try
                {
                    consoleEdit.AppendText(text + "\n");
                } catch (Exception e)
                {
                 
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void SetVisibleCore(bool value)
        {
            if (this.IsVisibilityChangeAllowed)
            {
                base.SetVisibleCore(value);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            IsVisibilityChangeAllowed = true;

            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
            else
            {
                Hide();
                WindowState = FormWindowState.Minimized;
            }
        }
    }
}
