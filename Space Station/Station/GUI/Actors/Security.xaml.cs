using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Microsoft.Expression.Encoder.Devices;
using System.Data;
using System.Timers;
using System.IO;
using WebcamControl;
using System.Windows.Input;

namespace Station.GUI.Actors
{
    public partial class Security : Window
    {
        Timer T = new Timer();
        Classes.Security S = new Classes.Security();
        Classes.Options Op;
        Classes.Input IM;

        DataTable dt, dt2;
        DataRow Info;

        bool StartStop = true, StartRec = true;
        string UserName;

        public Security(DataRow Info)
        {
            InitializeComponent();

            this.Info = Info;

            txt_Name.Text = Info["name"].ToString();
            UserName = Info["user_name"].ToString();
            if (Info["photo"] != DBNull.Value)
                Photo.ImageSource = Classes.Person.ByteToImage((byte[])Info["photo"]);

            txt_Search_TextChanged(null, null);

            CheckFault();
            CameraCofig();

            Op = new Classes.Options(Options);
            IM = new Classes.Input(txt_Message);

            T.Elapsed += new ElapsedEventHandler(myEvent);
            T.Interval = 5000;
            T.Enabled = true;
        }

        #region (Contact - Alarm - Configuration - Start - Record - Capture) Buttons

        #region Contact
        private void btn_Contact_Click(object sender, RoutedEventArgs e)
        {
            Contact C = new Contact(UserName);
            C.ShowDialog();
        }
        #endregion

        #region Alarm
        private void btn_Alarm_Click(object sender, RoutedEventArgs e)
        {
            IM.Message("Alarm Is Launched");
        }
        #endregion

        #region Configuration
        private void btn_conf_Click(object sender, RoutedEventArgs e)
        {
            Config.Visibility = (Config.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible);
        }
        #endregion

        #region Start / Stop Camera
        private void btn_Start_Stop_Click(object sender, RoutedEventArgs e)
        {
            Config.Visibility = Visibility.Hidden;

            if (StartStop)
            {
                StartStop = !StartStop;
                btn_Start_Stop.Content = "Stop";
                try
                {
                    Camera.StartPreview();
                    IM.Message("Camera Started Successfully");
                }
                catch(Exception ee)
                {
                    if(ee.Message.Contains("assembly"))
                    {
                        IM.Message("Please Install Microsoft Expression Encoder Library !");
                    }else
                    IM.Message("Sorry Device is in use by another app !");
                }
               
            }
            else
            {
                IM.Message("Camera stoped !");

                btn_Start_Stop.Content = "Start";
                Camera.StopPreview();
                StartStop = !StartStop;
            }
        }
        #endregion

        #region Recording
        private void btn_Record_Stop_Click(object sender, RoutedEventArgs e)
        {
            Config.Visibility = Visibility.Hidden;

            if (StartRec)
            {
                if (!StartStop)
                {
                    IM.Message("Recording !");

                    Camera.StartRecording();
                    btn_Record_Stop.Content = "Stop Recording";
                    StartRec = !StartRec;
                }
            }
            else
            {
                IM.Message("Stop Recording !");

                Camera.StopRecording();
                btn_Record_Stop.Content = "Start";
                StartRec = !StartRec;
            }
        }
        #endregion

        #region Capture Image
        private void btn_Capture_Click(object sender, RoutedEventArgs e)
        {
            Config.Visibility = Visibility.Hidden;

            IM.Message("Image Captured !");

            Camera.TakeSnapshot();
        }
        #endregion

        #endregion

        #region Search Text

        private void txt_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LV_Access.Items.Clear();
            if (txt_Search.Text.Length > 0)
            {
                Hint.Visibility = Visibility.Hidden;
                dt = S.checkAccess(txt_Search.Text);
            }
            else
            {
                Hint.Visibility = Visibility.Visible;
                dt = S.checkAccess(Name);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
                LV_Access.Items.Add(dt.Rows[i]["name"]);
        }

        #endregion

        #region Selection Changed Events

        #region LV Access Selection Changed

        private void LV_Access_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < LV_Access.Items.Count; i++)
                if (LV_Access.Items[i] == LV_Access.SelectedItem)
                {
                    clear();
                    txt_AName.Text = dt.Rows[i]["name"].ToString();
                    txt_ADate.Text = dt.Rows[i]["date_of_access"].ToString();
                    txt_Jop.Text = dt.Rows[i]["jop"].ToString();
                    txt_Access.Text = dt.Rows[i]["access"].ToString();
                    string LAccess, Lseen;
                    S.LastSeen(dt.Rows[i]["user_name"].ToString(), out LAccess, out Lseen);
                    txt_LAccess.Text = LAccess;
                    txt_LSeen.Text = Lseen;
                    break;
                }
        }

        #endregion

        #region LV Fault Selection Changed

        private void LV_Fault_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < LV_Fault.Items.Count; i++)
                if (LV_Fault.Items[i] == LV_Fault.SelectedItem)
                {
                    clear();
                    txt_AName.Text = dt2.Rows[i]["name"].ToString();
                    txt_ADate.Text = dt2.Rows[i]["date_of_access"].ToString();
                    break;
                }
        }

        #endregion

        #endregion

        #region Camera Configuration

        private void CameraCofig()
        {
            Binding Binding1 = new Binding("SelectedValue");
            Binding1.Source = cmb_Video;
            Camera.SetBinding(Webcam.VideoDeviceProperty, Binding1);

            Binding Binding2 = new Binding("SelectedValue");
            Binding2.Source = cmb_Audio;
            Camera.SetBinding(Webcam.AudioDeviceProperty, Binding2);

            string VideoPath = @"C:\VideoClips";

            if (!Directory.Exists(VideoPath))
                Directory.CreateDirectory(VideoPath);

            string ImagePath = @"C:\WebcamSnapshots";

            if (!Directory.Exists(ImagePath))
                Directory.CreateDirectory(ImagePath);

            Camera.VideoDirectory = VideoPath;
            Camera.ImageDirectory = ImagePath;

            Camera.FrameRate = 30;
            Camera.FrameSize = new System.Drawing.Size(1366, 768);

            var VideoDevices = EncoderDevices.FindDevices(EncoderDeviceType.Video);
            var AudioDevices = EncoderDevices.FindDevices(EncoderDeviceType.Audio);
            cmb_Video.ItemsSource = VideoDevices;
            cmb_Audio.ItemsSource = AudioDevices;

            cmb_Video.SelectedIndex = 0;
            cmb_Audio.SelectedIndex = 0;
        }

        #endregion

        #region Methods

        #region Check Fault Access Pepole

        private void CheckFault()
        {
            dt2 = S.faultAccess();
            LV_Fault.Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate
            {
                LV_Fault.Items.Clear();
                for (int i = 0; i < dt2.Rows.Count; i++)
                    LV_Fault.Items.Add((i + 1));
            }));
        }

        #endregion

        #region Clear

        private void clear()
        {
            txt_AName.Clear();
            txt_ADate.Clear();
            txt_LAccess.Clear();
            txt_LSeen.Clear();
            txt_Jop.Clear();
            txt_Access.Clear();
        }

        #endregion

        #endregion

        #region My Event

        private void myEvent(object source, ElapsedEventArgs e)
        {
            CheckFault();
        }

        #endregion

        #region (Edit Info - Logout - open/close) MouseDown Events - Age Input

        private void Ellipse_Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Op.Show();
        }

        private void EditInfo_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Edit_Information EI = new Edit_Information(UserName);
            EI.ShowDialog();
        }

        private void Logout_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Main M = new Main();
            this.Close();
            T.Enabled = false;
            S.logout(UserName);
            M.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            S.logout(UserName);
            Op.Close();
            T.Stop();
        }

        #endregion
    }
}
