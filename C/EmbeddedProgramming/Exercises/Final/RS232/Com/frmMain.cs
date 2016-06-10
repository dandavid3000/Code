using System;
using System.Windows.Forms;

namespace ComPort
{
    public partial class frmMain : Form
    {
        ComManager cM;

        public frmMain()
        {
            InitializeComponent();
            cM = new ComManager();
            cM.DataReceived += new ComManager.DataReceivedHandler(cM_DataReceived);
            txtInput.Text = getTime();
        }

        void cM_DataReceived(byte[] nData)
        {
            string text = nData.Length.ToString() + "\t";
            foreach (byte c in nData)
                text += (char)c;

           txtOutput.Text = text + "\r\n" + txtOutput.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtOutput.Clear();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            char[] c = txtInput.Text.ToCharArray();
            byte[] n = new byte[c.Length];
            for (int i = 0; i < c.Length; i++)
                n[i] = (byte)c[i];
            txtInput.Text = null;
            cM.Write(n);
            timer1.Start();
        }
        private string getTime()
        {
            DateTime d = DateTime.Now;
            string str = d.Hour.ToString() +":"+ d.Minute.ToString()+":"+d.Second.ToString();
            return str;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string s = getTime();
            char[] c = s.ToCharArray();
            byte[] n = new byte[c.Length];
            for (int i = 0; i < c.Length; i++)
                n[i] = (byte)c[i];
            txtInput.Text = null;
            cM.Write(n);
            Invalidate();
        }


    }
}
