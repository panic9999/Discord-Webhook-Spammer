using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Collections.Specialized;

namespace Webhook_Spammer
{
    public partial class Tool : Form
    {
        public Tool()
        {
            InitializeComponent();
            label5.Text = "Ready";
            label5.ForeColor = Color.LimeGreen;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/panic9999");
        }
        bool active = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if(timer1.Interval != null)
            { 
                try { 
                    timer1.Interval = Int32.Parse(textBox1.Text);
                }
                catch(Exception ex)
                {
                    timer1.Interval = 300;
                }
            }
            else
            {
                timer1.Interval = 300;
            }
            if(richTextBox1.TextLength > 0)
            {
                if (active)
                {
                    sent = 0;
                    active = false;
                    timer1.Enabled = false;
                    label2.Text = "Sent Messages: 0";
                    button1.Text = "Start Spamming";
                }
                else
                {
                    sent = 0;
                    active = true;
                    timer1.Enabled = true;
                    label2.Text = "Sent Messages: 0";
                    button1.Text = "Stop Spamming";
                }
            }
        }
        int sent = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            try
            {
                wc.UploadValues(textBox2.Text, new NameValueCollection
            {
                {
                    "content", richTextBox1.Text
                },
                {
                    "username", "Why Are You Running"
                }
            });
                label5.Text = "Ready";
                label5.ForeColor = Color.LimeGreen;
                sent = sent + 1;
                label2.Text = "Sent Messages: " + sent.ToString();
            }
            catch (WebException ex)
            {
                label5.Text = "Rate Limited, Please Wait";
                label5.ForeColor = Color.Crimson;
            }
        }
    }
}
