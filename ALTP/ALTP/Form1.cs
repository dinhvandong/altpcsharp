using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALTP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Timer timer2 = new Timer
        {
            Interval = 1000
        };
       

        private static FileStream fs = new FileStream(@"c:\temp\mcb.txt", FileMode.OpenOrCreate, FileAccess.Write);
        private static StreamWriter m_streamWriter = new StreamWriter(fs);
        static DateTime  start=DateTime.UtcNow;
        static DateTime  endTime = DateTime.UtcNow;

        private void Form1_Load(object sender, EventArgs e)
        {


            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.Write(" File Write Operation Starts : ");
            m_streamWriter.WriteLine("{0} {1}",
            DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            m_streamWriter.WriteLine("===================================== \n");
            m_streamWriter.Flush();

            //button1.
            var minutes = 1; //countdown time
             start = DateTime.UtcNow; // Use UtcNow instead of Now
             endTime = start.AddMinutes(minutes); //endTime is a member, not a local variable
           // timer1.Enabled = true;

            timer2.Enabled = true;
            timer2.Tick += new System.EventHandler(OnTimerEvent);

        }
        public  void OnTimerEvent(object source, EventArgs e)
        {
            /* m_streamWriter.WriteLine("{0} {1}",
                 DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
             m_streamWriter.Flush();*/


            TimeSpan remainingTime = endTime - DateTime.UtcNow;
            if (remainingTime < TimeSpan.Zero)
            {
                lblTimer.Text = "Done!";
                lblTimer.Enabled = false;
            }
            else
            {
                lblTimer.Text = Convert.ToInt32(remainingTime.ToString("ss")) + "";
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;


        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            m_streamWriter.WriteLine("{0} {1}",
            DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            m_streamWriter.Flush();
        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }
    }
}
