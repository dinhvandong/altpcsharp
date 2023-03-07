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
       


        private static FileStream fs = 
            new FileStream(@"c:\temp\mcb.txt", FileMode.OpenOrCreate, FileAccess.Write);
        private static StreamWriter m_streamWriter = new StreamWriter(fs);
        static DateTime  start=DateTime.UtcNow;
        static DateTime  endTime = DateTime.UtcNow;

        static int[] anwsers = { 1, 2, 3, 4 };
        static int correct = 2;
        static int anwser = 0;

        private void Form1_Load(object sender, EventArgs e)
        {


            m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
            m_streamWriter.Write(" File Write Operation Starts : ");
            m_streamWriter.WriteLine("{0} {1}",
            DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            m_streamWriter.WriteLine("===================================== \n");
            m_streamWriter.Flush();

            pictureBox13.MouseClick += pictureBox13_Click;

            //button1.
            timer2.Enabled = true;
            timer2.Start();
            timer2.Interval = 1000;

            var minutes = 1; //countdown time
            start = DateTime.UtcNow; // Use UtcNow instead of Now
            endTime = start.AddMinutes(minutes); //endTime is a member, not a local variable
                                                 // timer1.Enabled = true;
            timer2.Tick += new System.EventHandler(OnTimerEvent);


        }
        public  void OnTimerEvent(object source, EventArgs e)
        {

            TimeSpan remainingTime = endTime - DateTime.UtcNow;
            if (remainingTime < TimeSpan.Zero)
            {
                lblTime.Enabled = false;

                // check Anwser vs Correct
                if(anwser==correct)
                {
                    lblTime.Text = "Đúng";

                    if (anwser==1)
                    {

                        // Button A change color
                        button1.BackColor = System.Drawing.Color.Green;
                    }
                    else if(anwser ==2)
                    {
                        // Button B change color
                        button2.BackColor = System.Drawing.Color.Green;

                    }
                    else if(anwser==3)
                    {
                        // Button C change color
                        button3.BackColor = System.Drawing.Color.Green;

                    }
                    else if(anwser ==4)
                    {
                        // Button D change color

                        button4.BackColor = System.Drawing.Color.Green;

                    }
                }
                else
                {
                    lblTime.Text = "Sai";
                    if (anwser == 1)
                    {
                        // Button A change color

                        button1.BackColor = System.Drawing.Color.Red;

                    }
                    else if (anwser == 2)
                    {
                        // Button B change color
                        button2.BackColor = System.Drawing.Color.Red;

                    }
                    else if (anwser == 3)
                    {
                        // Button C change color
                        button3.BackColor = System.Drawing.Color.Red;

                    }
                    else if (anwser == 4)
                    {
                        // Button D change color
                        button4.BackColor = System.Drawing.Color.Red;

                    }
                }
            }
            else
            {
                lblTime.Text = Convert.ToInt32(remainingTime.ToString("ss")) + "";
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void clickMouse()
        {
            MessageBox.Show("Hello");

        }
        private void pictureBox13_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Hello");
           

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            timer2.Stop();


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

        private void button1_Click(object sender, EventArgs e)
        {
            anwser = 1;
           // Control ctr1 = (Control)sender;
            button1.BackColor = System.Drawing.Color.Yellow;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            anwser = 2;
            button2.BackColor = System.Drawing.Color.Yellow;
            /*Control ctr2 = (Control)sender;
            ctr2.BackColor = System.Drawing.Color.Yellow;*/

        }

        private void button3_Click(object sender, EventArgs e)
        {
            anwser = 3;
          //  Control ctr3 = (Control)sender;
            button3.BackColor = System.Drawing.Color.Yellow;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            anwser = 4;
           // Control ctr4 = (Control)sender;
            button4.BackColor = System.Drawing.Color.Yellow;
        }

      /*  private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = System.Drawing.Color.Yellow;
        }*/
    }
}
