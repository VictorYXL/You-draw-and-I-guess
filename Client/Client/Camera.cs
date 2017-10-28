using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;

namespace Client
{
    public partial class Camera : Form
    {
        VideoCaptureDevice camera;
        Panel mp;
        FilterInfoCollection videoDevices;
        public Camera(Panel mp)
        {
            this.mp = mp;
            this.Disposed += Camera_Disposed;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            for (int i = 0; i < videoDevices.Count; i++)
            {
                String videoName = videoDevices[i].Name;
                if (videoName.Substring(0, 5) != "Corel")
                    cmb_Camrea.Items.Add(videoName);
                else {
                    videoDevices.RemoveAt(i);
                    i--;
                }
                camera = null;
            }

        }

        void Camera_Disposed(object sender, EventArgs e)
        {
            videoPlayer.SignalToStop();
            videoPlayer.WaitForStop();
        }

        private void cmb_Camrea_SelectedIndexChanged(object sender, EventArgs e)
        {
            camera = new VideoCaptureDevice(videoDevices[cmb_Camrea.SelectedIndex].MonikerString);
            camera.DesiredFrameSize = new Size(540,400);
            camera.DesiredFrameRate = 1;
            this.videoPlayer.VideoSource = camera;
            this.videoPlayer.Start();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            videoPlayer.SignalToStop();
            videoPlayer.WaitForStop();
            this.Dispose();
        }

        private void btn_Grap_Click(object sender, EventArgs e)
        {
            Bitmap img = new Bitmap(740, 400);
            videoPlayer.DrawToBitmap(img,new Rectangle(100,0,videoPlayer.Width,videoPlayer.Height));
            mp.DrawCamera(img);
            videoPlayer.SignalToStop();
            videoPlayer.WaitForStop();
            this.Dispose();

        }
    }
}
