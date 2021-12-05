using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My7SegmentDateTime
{
    public partial class Form1 : Form
    {


        int hour_1;
        int hour_2;
        int minute_1;
        int minute_2;
        int seconds_1;
        int seconds_2;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            mainFunction();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //mainFunction();
        }



        private void mainFunction()
        {
            String myTimeStr = DateTime.Now.ToLongTimeString();
            String myDateStr = DateTime.Now.ToLongDateString();


            String hoursStr = "";
            String minutesStr = "";
            String secondsStr = "";

            String myTimeStrCopy = myTimeStr;// "2:22:32 PM";
            String temporaryStr = "";
            

            hoursStr = myTimeStrCopy.Substring(0, myTimeStrCopy.IndexOf(':'));
            temporaryStr = myTimeStrCopy.Remove(0, myTimeStrCopy.IndexOf(':') + 1);

            minutesStr = temporaryStr.Substring(0, temporaryStr.IndexOf(':'));
            temporaryStr = temporaryStr.Remove(0, temporaryStr.IndexOf(':') + 1);

            secondsStr = temporaryStr.Substring(0, temporaryStr.IndexOf(' '));
            temporaryStr = temporaryStr.Remove(0, temporaryStr.IndexOf(' ') + 1);


            lblTimePeriod_AM_or_PM.Text = temporaryStr;
            lblDisplayDate.Text = myDateStr;
            
            if (hoursStr.Length == 1)
            {
                hour_1 = 0;
                hour_2 = int.Parse(hoursStr);
            }
            else if (hoursStr.Length == 2)
            {
                hour_1 = int.Parse(hoursStr[0].ToString());
                hour_2 = int.Parse(hoursStr[1].ToString());
            }


            if (minutesStr.Length == 1)
            {
                minute_1 = 0;
                minute_2 = int.Parse(minutesStr);
            }
            else if (minutesStr.Length == 2)
            {
                minute_1 = int.Parse(minutesStr[0].ToString());
                minute_2 = int.Parse(minutesStr[1].ToString());
            }


            if (secondsStr.Length == 1)
            {
                seconds_1 = 0;
                seconds_2 = int.Parse(secondsStr);
            }
            else if (secondsStr.Length == 2)
            {
                seconds_1 = int.Parse(secondsStr[0].ToString());
                seconds_2 = int.Parse(secondsStr[1].ToString());
            }




            my7SegmentEncoder(hour_1, ref btnH_1_A, ref btnH_1_B, ref btnH_1_C, ref btnH_1_D, ref btnH_1_E, ref btnH_1_F, ref btnH_1_G);
            my7SegmentEncoder(hour_2, ref btnH_2_A, ref btnH_2_B, ref btnH_2_C, ref btnH_2_D, ref btnH_2_E, ref btnH_2_F, ref btnH_2_G);
            my7SegmentEncoder(minute_1, ref btnM_1_A, ref btnM_1_B, ref btnM_1_C, ref btnM_1_D, ref btnM_1_E, ref btnM_1_F, ref btnM_1_G);
            my7SegmentEncoder(minute_2, ref btnM_2_A, ref btnM_2_B, ref btnM_2_C, ref btnM_2_D, ref btnM_2_E, ref btnM_2_F, ref btnM_2_G);
            my7SegmentEncoder(seconds_1, ref btnS_1_A, ref btnS_1_B, ref btnS_1_C, ref btnS_1_D, ref btnS_1_E, ref btnS_1_F, ref btnS_1_G);
            my7SegmentEncoder(seconds_2, ref btnS_2_A, ref btnS_2_B, ref btnS_2_C, ref btnS_2_D, ref btnS_2_E, ref btnS_2_F, ref btnS_2_G);

        }

        private Color segmentLEDColor_ON()
        {
            return Color.Red;
        }

        private Color segmentLEDColor_OFF()
        {
            return Color.Black;
        }

        private void letSegmentLED_ON_or_OFF(ref Button btnLED, bool isLED_On)
        {
            if(isLED_On)
            {
                btnLED.BackColor = Color.Red;
                btnLED.Visible = true;
            }
            else
            {
                btnLED.BackColor = Color.Black;
                btnLED.Visible = false;
            }
        }

        private bool my7SegmentEncoder(int numDigit, ref Button btn_A, ref Button btn_B, ref Button btn_C, ref Button btn_D, ref Button btn_E, ref Button btn_F, ref Button btn_G)
        {
            this.BackColor = Color.Black;
            //menuStrip1.BackColor = Color.Black;
            //helpMenu.BackColor = Color.White;

            //btn_A.ForeColor = Color.Blue;

            
            if (numDigit == 0)
            {
                letSegmentLED_ON_or_OFF(ref btn_A, true);
                letSegmentLED_ON_or_OFF(ref btn_B, true);
                letSegmentLED_ON_or_OFF(ref btn_C, true);
                letSegmentLED_ON_or_OFF(ref btn_D, true);
                letSegmentLED_ON_or_OFF(ref btn_E, true);
                letSegmentLED_ON_or_OFF(ref btn_F, true);
                letSegmentLED_ON_or_OFF(ref btn_G, false);

                return true;

            }

            else if (numDigit == 1)
            {
                letSegmentLED_ON_or_OFF(ref btn_A, false);
                letSegmentLED_ON_or_OFF(ref btn_B, true);
                letSegmentLED_ON_or_OFF(ref btn_C, true);
                letSegmentLED_ON_or_OFF(ref btn_D, false);
                letSegmentLED_ON_or_OFF(ref btn_E, false);
                letSegmentLED_ON_or_OFF(ref btn_F, false);
                letSegmentLED_ON_or_OFF(ref btn_G, false);

                return true;
            }


            else if (numDigit == 2)
            {
                letSegmentLED_ON_or_OFF(ref btn_A, true);
                letSegmentLED_ON_or_OFF(ref btn_B, true);
                letSegmentLED_ON_or_OFF(ref btn_C, false);
                letSegmentLED_ON_or_OFF(ref btn_D, true);
                letSegmentLED_ON_or_OFF(ref btn_E, true);
                letSegmentLED_ON_or_OFF(ref btn_F, false);
                letSegmentLED_ON_or_OFF(ref btn_G, true);

                return true;
            }


            else if (numDigit == 3)
            {
                letSegmentLED_ON_or_OFF(ref btn_A, true);
                letSegmentLED_ON_or_OFF(ref btn_B, true);
                letSegmentLED_ON_or_OFF(ref btn_C, true);
                letSegmentLED_ON_or_OFF(ref btn_D, true);
                letSegmentLED_ON_or_OFF(ref btn_E, false);
                letSegmentLED_ON_or_OFF(ref btn_F, false);
                letSegmentLED_ON_or_OFF(ref btn_G, true);

                return true;
            }


            else if (numDigit == 4)
            {
                letSegmentLED_ON_or_OFF(ref btn_A, false);
                letSegmentLED_ON_or_OFF(ref btn_B, true);
                letSegmentLED_ON_or_OFF(ref btn_C, true);
                letSegmentLED_ON_or_OFF(ref btn_D, false);
                letSegmentLED_ON_or_OFF(ref btn_E, false);
                letSegmentLED_ON_or_OFF(ref btn_F, true);
                letSegmentLED_ON_or_OFF(ref btn_G, true);

                return true;
            }


            else if (numDigit == 5)
            {
                letSegmentLED_ON_or_OFF(ref btn_A, true);
                letSegmentLED_ON_or_OFF(ref btn_B, false);
                letSegmentLED_ON_or_OFF(ref btn_C, true);
                letSegmentLED_ON_or_OFF(ref btn_D, true);
                letSegmentLED_ON_or_OFF(ref btn_E, false);
                letSegmentLED_ON_or_OFF(ref btn_F, true);
                letSegmentLED_ON_or_OFF(ref btn_G, true);

                return true;
            }

            else if (numDigit == 6)
            {
                letSegmentLED_ON_or_OFF(ref btn_A, true);
                letSegmentLED_ON_or_OFF(ref btn_B, false);
                letSegmentLED_ON_or_OFF(ref btn_C, true);
                letSegmentLED_ON_or_OFF(ref btn_D, true);
                letSegmentLED_ON_or_OFF(ref btn_E, true);
                letSegmentLED_ON_or_OFF(ref btn_F, true);
                letSegmentLED_ON_or_OFF(ref btn_G, true);

                return true;
            }

            else if (numDigit == 7)
            {
                letSegmentLED_ON_or_OFF(ref btn_A, true);
                letSegmentLED_ON_or_OFF(ref btn_B, true);
                letSegmentLED_ON_or_OFF(ref btn_C, true);
                letSegmentLED_ON_or_OFF(ref btn_D, false);
                letSegmentLED_ON_or_OFF(ref btn_E, false);
                letSegmentLED_ON_or_OFF(ref btn_F, false);
                letSegmentLED_ON_or_OFF(ref btn_G, false);

                return true;
            }


            else if (numDigit == 8)
            {
                letSegmentLED_ON_or_OFF(ref btn_A, true);
                letSegmentLED_ON_or_OFF(ref btn_B, true);
                letSegmentLED_ON_or_OFF(ref btn_C, true);
                letSegmentLED_ON_or_OFF(ref btn_D, true);
                letSegmentLED_ON_or_OFF(ref btn_E, true);
                letSegmentLED_ON_or_OFF(ref btn_F, true);
                letSegmentLED_ON_or_OFF(ref btn_G, true);

                return true;
            }


            else if (numDigit == 9)
            {
                letSegmentLED_ON_or_OFF(ref btn_A, true);
                letSegmentLED_ON_or_OFF(ref btn_B, true);
                letSegmentLED_ON_or_OFF(ref btn_C, true);
                letSegmentLED_ON_or_OFF(ref btn_D, true);
                letSegmentLED_ON_or_OFF(ref btn_E, false);
                letSegmentLED_ON_or_OFF(ref btn_F, true);
                letSegmentLED_ON_or_OFF(ref btn_G, true);

                return true;
            }
            else
            {

                letSegmentLED_ON_or_OFF(ref btn_A, false);
                letSegmentLED_ON_or_OFF(ref btn_B, false);
                letSegmentLED_ON_or_OFF(ref btn_C, false);
                letSegmentLED_ON_or_OFF(ref btn_D, false);
                letSegmentLED_ON_or_OFF(ref btn_E, false);
                letSegmentLED_ON_or_OFF(ref btn_F, false);
                letSegmentLED_ON_or_OFF(ref btn_G, false);
                /*
                btn_A.BackColor = Color.Black;
                btn_B.BackColor = Color.Black;
                btn_C.BackColor = Color.Black;
                btn_D.BackColor = Color.Black;
                btn_E.BackColor = Color.Black;
                btn_F.BackColor = Color.Black;
                btn_G.BackColor = Color.Black;
                */
                return false;
            }
                
        }
        /*
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //*/
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By: Frederick B. Tan", "7 Segment Display Date and Time");
        }

    }
}
