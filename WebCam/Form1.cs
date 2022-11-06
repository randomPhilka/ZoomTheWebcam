using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;

using System.IO.Ports;
using System.Threading;

using System.Runtime.InteropServices;

namespace WebCam
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;

        static SerialPort _serialPort;

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        

        public Form1()
        {
            InitializeComponent();
            //First
            topFirstRange = (int)(pictureBox1.Top - (pictureBox1.Height * 0.1));
            leftFirstRange = (int)(pictureBox1.Left - (pictureBox1.Width * 0.1));
            heightFirstRange = (int)(pictureBox1.Height + (pictureBox1.Height * 0.15));
            widthFirstRange = (int)(pictureBox1.Width + (pictureBox1.Width * 0.15));
            //Thecond
            topSecondRange = (int)(pictureBox1.Top - (pictureBox1.Height * 0.2));
            leftSecondRange = (int)(pictureBox1.Left - (pictureBox1.Width * 0.2));
            heightSecondRange = (int)(pictureBox1.Height + (pictureBox1.Height * 0.25));
            widthSecondRange = (int)(pictureBox1.Width + (pictureBox1.Width * 0.25));
            //Third
            topThirdRange = (int)(pictureBox1.Top - (pictureBox1.Height * 0.3));
            leftThirdRange = (int)(pictureBox1.Left - (pictureBox1.Width * 0.3));
            heightThirdRange = (int)(pictureBox1.Height + (pictureBox1.Height * 0.35));
            widthThirdRange = (int)(pictureBox1.Width + (pictureBox1.Width * 0.35));
            //Fourth
            topFourthRange = (int)(pictureBox1.Top - (pictureBox1.Height * 0.4));
            leftFourthRange = (int)(pictureBox1.Left - (pictureBox1.Width * 0.4));
            heightFourthRange = (int)(pictureBox1.Height + (pictureBox1.Height * 0.45));
            widthFourthRange = (int)(pictureBox1.Width + (pictureBox1.Width * 0.45));
            //Fifth
            topFifthRange = (int)(pictureBox1.Top - (pictureBox1.Height * 0.5));
            leftFifthRange = (int)(pictureBox1.Left - (pictureBox1.Width * 0.5));
            heightFifthRange = (int)(pictureBox1.Height + (pictureBox1.Height * 0.55));
            widthFifthRange = (int)(pictureBox1.Width + (pictureBox1.Width * 0.55));
            //Sixth
            topSixthRange = (int)(pictureBox1.Top - (pictureBox1.Height * 0.6));
            leftSixthRange = (int)(pictureBox1.Left - (pictureBox1.Width * 0.6));
            heightSixthRange = (int)(pictureBox1.Height + (pictureBox1.Height * 0.65));
            widthSixthRange = (int)(pictureBox1.Width + (pictureBox1.Width * 0.65));
            //Seventh
            topSeventhRange = (int)(pictureBox1.Top - (pictureBox1.Height * 0.7));
            leftSeventhRange = (int)(pictureBox1.Left - (pictureBox1.Width * 0.7));
            heightSeventhRange = (int)(pictureBox1.Height + (pictureBox1.Height * 0.75));
            widthSeventhRange = (int)(pictureBox1.Width + (pictureBox1.Width * 0.75));
            //Eighth
            topEighthRange = (int)(pictureBox1.Top - (pictureBox1.Height * 0.8));
            leftEighthRange = (int)(pictureBox1.Left - (pictureBox1.Width * 0.8));
            heightEighthRange = (int)(pictureBox1.Height + (pictureBox1.Height * 0.85));
            widthEighthRange = (int)(pictureBox1.Width + (pictureBox1.Width * 0.85));
            //Ninth
            topNinthRange = (int)(pictureBox1.Top - (pictureBox1.Height * 0.9));
            leftNinthRange = (int)(pictureBox1.Left - (pictureBox1.Width * 0.9));
            heightNinthRange = (int)(pictureBox1.Height + (pictureBox1.Height * 0.95));
            widthNinthRange = (int)(pictureBox1.Width + (pictureBox1.Width * 0.95));
            //Tenth
            topTenthRange = (int)(pictureBox1.Top - (pictureBox1.Height * 1));
            leftTenthRange = (int)(pictureBox1.Left - (pictureBox1.Width * 1));
            heightTenthRange = (int)(pictureBox1.Height + (pictureBox1.Height * 1.5));
            widthTenthRange = (int)(pictureBox1.Width + (pictureBox1.Width * 1.5));


            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            if (_serialPort == null)
            {
                _serialPort = new SerialPort();
                _serialPort.PortName = "COM3";
                _serialPort.BaudRate = 9600;
                _serialPort.Open();
            }

            int form = (int)(pictureBox1.Top - (pictureBox1.Height * 0.025));


        }

        //First
        int topFirstRange;
        int leftFirstRange;
        int heightFirstRange;
        int widthFirstRange;
        //Second
        int topSecondRange;
        int leftSecondRange;
        int heightSecondRange;
        int widthSecondRange;
        //Third
        int topThirdRange;
        int leftThirdRange;
        int heightThirdRange;
        int widthThirdRange;
        //Fourth
        int topFourthRange;
        int leftFourthRange;
        int heightFourthRange;
        int widthFourthRange;
        //Fifth
        int topFifthRange;
        int leftFifthRange;
        int heightFifthRange;
        int widthFifthRange;
        //Sixth
        int topSixthRange;
        int leftSixthRange;
        int heightSixthRange;
        int widthSixthRange;
        //Seventh
        int topSeventhRange;
        int leftSeventhRange;
        int heightSeventhRange;
        int widthSeventhRange;
        //Eighth
        int topEighthRange;
        int leftEighthRange;
        int heightEighthRange;
        int widthEighthRange;
        //Ninth
        int topNinthRange;
        int leftNinthRange;
        int heightNinthRange;
        int widthNinthRange;
        //Tenth
        int topTenthRange;
        int leftTenthRange;
        int heightTenthRange;
        int widthTenthRange;

        void timer_Tick(object sender, EventArgs e)
        {
            _serialPort.NewLine = "\n";
            string test3 = _serialPort.ReadExisting();
            string y;
            int SlashPos = test3.IndexOf("\n");

            if (SlashPos > 0)
                y = test3.Substring(0, SlashPos);
            else
                y = test3;

            label1.Text = y;

         
            if (Enumerable.Range(0, 10).Contains(Convert.ToInt32(y)))
            {
                    pictureBox1.Top = topFirstRange;
                    pictureBox1.Left = leftFirstRange;
                    pictureBox1.Height = heightFirstRange;
                    pictureBox1.Width = widthFirstRange;
            }
            else if (Enumerable.Range(11, 60).Contains(Convert.ToInt32(y)))
            {
                    pictureBox1.Top = topSecondRange;
                    pictureBox1.Left = leftSecondRange;
                    pictureBox1.Height = heightSecondRange;
                    pictureBox1.Width = widthSecondRange;
            }
            else if (Enumerable.Range(61, 110).Contains(Convert.ToInt32(y)))
            {
                pictureBox1.Top = topThirdRange;
                pictureBox1.Left = leftThirdRange;
                pictureBox1.Height = heightThirdRange;
                pictureBox1.Width = widthThirdRange;
            }
            else if (Enumerable.Range(111, 170).Contains(Convert.ToInt32(y)))
            {
                pictureBox1.Top = topFourthRange;
                pictureBox1.Left = leftFourthRange;
                pictureBox1.Height = heightFourthRange;
                pictureBox1.Width = widthFourthRange;
            }
            else if (Enumerable.Range(171, 230).Contains(Convert.ToInt32(y)))
            {
                pictureBox1.Top = topFifthRange;
                pictureBox1.Left = leftFifthRange;
                pictureBox1.Height = heightFifthRange;
                pictureBox1.Width = widthFifthRange;
            }
            else if (Enumerable.Range(231, 350).Contains(Convert.ToInt32(y)))
            {
                pictureBox1.Top = topSixthRange;
                pictureBox1.Left = leftSixthRange;
                pictureBox1.Height = heightSixthRange;
                pictureBox1.Width = widthSixthRange;
            }
            else if (Enumerable.Range(351, 500).Contains(Convert.ToInt32(y)))
            {
                pictureBox1.Top = topSeventhRange;
                pictureBox1.Left = leftSeventhRange;
                pictureBox1.Height = heightSeventhRange;
                pictureBox1.Width = widthSeventhRange;
            }
            else if (Enumerable.Range(501, 650).Contains(Convert.ToInt32(y)))
            {
                pictureBox1.Top = topEighthRange;
                pictureBox1.Left = leftEighthRange;
                pictureBox1.Height = heightEighthRange;
                pictureBox1.Width = widthEighthRange;
            }
            else if (Enumerable.Range(651, 750).Contains(Convert.ToInt32(y)))
            {
                pictureBox1.Top = topNinthRange;
                pictureBox1.Left = leftNinthRange;
                pictureBox1.Height = heightNinthRange;
                pictureBox1.Width = widthNinthRange;
            }
            else if (Enumerable.Range(751, 1024).Contains(Convert.ToInt32(y)))
            {
                pictureBox1.Top = topTenthRange;
                pictureBox1.Left = leftTenthRange;
                pictureBox1.Height = heightTenthRange;
                pictureBox1.Width = widthTenthRange;
            }
        }


        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

        private void _zoomInButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = (int)(pictureBox1.Top - (pictureBox1.Height * 0.025));
            pictureBox1.Left = (int)(pictureBox1.Left - (pictureBox1.Width * 0.025));
            pictureBox1.Height = (int)(pictureBox1.Height + (pictureBox1.Height * 0.05));
            pictureBox1.Width = (int)(pictureBox1.Width + (pictureBox1.Width * 0.05));

        }

        private void _zoomOutButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = (int)(pictureBox1.Top + (pictureBox1.Height * 0.025));
            pictureBox1.Left = (int)(pictureBox1.Left + (pictureBox1.Width * 0.025));
            pictureBox1.Height = (int)(pictureBox1.Height - (pictureBox1.Height * 0.05));
            pictureBox1.Width = (int)(pictureBox1.Width - (pictureBox1.Width * 0.05));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name);
            }

            comboBox1.SelectedIndex = 0;
            FinalVideo = new VideoCaptureDevice();

            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (FinalVideo.IsRunning == true) FinalVideo.Stop();

            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[comboBox1.SelectedIndex].MonikerString);
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalVideo_NewFrame);
            FinalVideo.Start();
        }

        void FinalVideo_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap video = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = video;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FinalVideo.IsRunning == true) FinalVideo.Stop();
        }
    }
}
