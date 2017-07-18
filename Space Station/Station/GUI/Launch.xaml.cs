using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Shuttle.Classes;
using System.Data;

namespace Station.GUI
{
    public partial class Launch : Window
    {
        byte stage;
        int time = 0, launchstage = 0, Count = 11;
        double distance, D, speed = 0, G = 9.8, Fuel, F = 0;
        string ShuttleUserName, Password, Message;
        bool[] LaunchStages = new bool[3];

        System.Timers.Timer Down = new System.Timers.Timer();
        System.Timers.Timer launchThread = new System.Timers.Timer();
        System.Timers.Timer T = new System.Timers.Timer();

        SpaceShuttle SS = new SpaceShuttle();
        Classes.Input I;

        DataRow AstronautInfo;

        public Launch(string[] Info, DataRow AstronautInfo, string ShuttleUserName, string Password)
        {
            InitializeComponent();

            txt_Name.Text = Info[0];
            txt_LTime.Text = Info[1];
            txt_Stages.Text = Info[2];
            txt_Distance_.Text = Info[3];
            txt_Fuel.Text = Info[4];

            this.ShuttleUserName = ShuttleUserName;
            this.Password = Password;
            this.AstronautInfo = AstronautInfo;

            rtb_Notes.Document.Blocks.Clear();
            rtb_Notes.Document.Blocks.Add(new Paragraph(new Run(Info[5])));
            distance = Convert.ToDouble(Info[3]);
            Fuel = Convert.ToDouble(Info[4]);
            D = distance;

            I = new Classes.Input(txt_message);

            Down.Interval = 1000;
            Down.Elapsed += Down_Elapsed;

            launchThread.Interval = 20;
            launchThread.Elapsed += launchShuttle;
        }

        #region Buttons

        #region Launch

        private void btn_Launch_Click(object sender, RoutedEventArgs e)
        {
            btn_Launch.IsEnabled = false;
            btn_Cancel.IsEnabled = false;
            LaunchControls.Visibility = Visibility.Visible;
            txt_Launch.Visibility = Visibility.Visible;
            Down.Start();
        }

        #endregion

        #region Ready

        private void btn_Ready_Click(object sender, RoutedEventArgs e)
        {
            DateTime LT = Convert.ToDateTime(txt_LTime.Text).Date;

            string Path = @"/Station;component/Resources/Wrong 2.png";

            if (LT.Date <= DateTime.Now.Date)
            {
                if (Convert.ToDouble(txt_Distance_.Text) >= 100000 && Convert.ToDouble(txt_Distance_.Text) <= 600000)
                {
                    if (Convert.ToDouble(txt_Fuel.Text) >= (Convert.ToDouble(txt_Distance_.Text) / 3))
                    {
                        Message = "Launch is ready";
                        Path = @"/Station;component/Resources/Correct.png";

                        btn_Warning.IsEnabled = true;
                        btn_Ready.IsEnabled = false;
                    }
                    else
                    {
                        Message = "Sorry the fuel isn't enough!";
                    }
                }
                else
                {
                    Message = "Distance is not suitable for launch!";
                }
            }
            else
            {
                Message = "It's not the launch time!";
            }

            I.Message(Message);
            ImageSource image = new BitmapImage(new Uri(Path, UriKind.RelativeOrAbsolute));
            Correct_Wrong.Source = image;
        }

        #endregion

        #region Warning

        private void btn_Warning_Click(object sender, RoutedEventArgs e)
        {
            Warning.Visibility = Visibility.Visible;
            btn_Warning.IsEnabled = false;
            I.Message("Warning!");
            ImageSource image = new BitmapImage(new Uri(@"/Station;component/Resources/Warning 1.png", UriKind.RelativeOrAbsolute));
            Correct_Wrong.Source = image;

            T.Interval = 5000;
            T.Elapsed += warn;
            T.Start();
        }

        #endregion

        #region Cancel

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Down.Enabled = false;
            launchThread.Enabled = false;
            T.Enabled = false;
            this.Close();
        }

        #endregion

        #endregion

        #region Threads

        #region Down Counter Thread

        private void Down_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            txt_Launch.Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate { txt_Launch.Text = (--Count).ToString(); }));
            if (Count == 0)
            {
                Correct_Wrong.Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate { Correct_Wrong.Visibility = Visibility.Hidden; }));
                Down.Stop();
                txt_Launch.Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate { txt_Launch.Visibility = Visibility.Hidden; }));

                launchThread.Start();
            }
        }

        #endregion

        #region Warning Thread

        private void warn(object sender, System.Timers.ElapsedEventArgs e)
        {
            CheckLaunch.Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate
            {
                Warning.Visibility = Visibility.Hidden;
                txt_Launch.Visibility = Visibility.Visible;
                btn_Ready.Visibility = Visibility.Hidden;
                btn_Warning.Visibility = Visibility.Hidden;
                btn_Launch.Visibility = Visibility.Visible;
                Warning.Visibility = Visibility.Hidden;

                LaunchControls.Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                {
                    txt_Speed.Text = speed.ToString();
                    txt_Distance.Text = txt_Distance_.Text;
                    txt_Time.Text = time.ToString();
                    txt_AFuel.Text = txt_Fuel.Text;
                    txt_Gravity.Text = G.ToString();
                }));
            }));
            T.Stop();
        }

        #endregion

        #region Launch Thread

        private void launchShuttle(object sender, System.Timers.ElapsedEventArgs e)
        {
            LaunchControls.Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate
            {
                if (distance > 0 && Fuel >= F)
                {
                    if (distance > (D / 5) && distance < 2 * (D / 5) && !LaunchStages[2])
                    {
                        stage = 3;
                        launchstage = 0;
                    }
                    else if (distance > 2 * (D / 5) && distance < 3 * (D / 5) && !LaunchStages[1])
                    {
                        stage = 2;
                        launchstage = 0;
                    }
                    else if (distance > 3 * (D / 5) && distance < 4 * (D / 5) && !LaunchStages[0])
                    {
                        stage = 1;
                        launchstage = 0;
                    }

                    if (stage == 1)
                    {
                        if (launchstage <= 30)
                            txt_Stage.Text = "Stage 1 is ready";
                        else
                            txt_Stage.Text = "Stage 1 is launched";
                        launchstage++;
                        LaunchStages[0] = true;
                    }
                    else if (stage == 2)
                    {
                        if (launchstage <= 30)
                            txt_Stage.Text = "Stage 2 is ready";
                        else
                            txt_Stage.Text = "Stage 2 is launched";
                        launchstage++;
                        LaunchStages[1] = true;
                    }
                    else if (stage == 3)
                    {
                        if (launchstage <= 30)
                            txt_Stage.Text = "Stage 3 is ready";
                        else
                            txt_Stage.Text = "Stage 3 is launched";
                        launchstage++;
                        LaunchStages[2] = true;

                        if (launchstage > 75)
                        {
                            txt_Stage.Clear();
                            stage = 4;
                        }
                    }

                    F = 0;
                    if (G > 0.01)
                        G -= 0.007;
                    else
                        G = 0.01;

                    if (distance <= D / 1.9)
                    {
                        if (speed > 15)
                            speed--;
                    }
                    else
                        speed++;

                    if (G > 2.5)
                    {
                        F = speed / 10 + G;
                        distance -= F * 5;
                    }
                    else
                    {
                        if (distance > 200 && G > 0)
                        {
                            F = speed + G;
                            distance -= F * 2;
                        }
                        else
                        {
                            if (distance >= 100)
                            {
                                F = speed;
                                distance -= F * 2;
                            }
                            else
                            {
                                if (distance < 10)
                                {
                                    distance -= 1;
                                    speed = 1;
                                }
                                else if (distance < 20)
                                {
                                    distance -= 3;
                                    speed = 3;
                                }
                                else if (distance < 50)
                                {
                                    distance -= 5;
                                    speed = 5;
                                }
                                else if (distance < 100)
                                {
                                    distance -= 10;
                                    speed = 10;
                                }
                            }
                            F = speed;
                        }
                    }
                    Fuel -= F;
                    txt_Speed.Text = speed.ToString();
                    txt_Distance.Text = distance.ToString();
                    txt_Time.Text = time++.ToString();
                    txt_AFuel.Text = Fuel.ToString();
                    txt_Gravity.Text = G.ToString();
                }
                else
                {
                    launchThread.Stop();
                    SS.NewShuttle(ShuttleUserName, Password, txt_Name.Text);

                    Space_Shuttle S = new Space_Shuttle(AstronautInfo, ShuttleUserName, txt_Name.Text);
                    Classes.Person P = new Classes.Person();
                    P.access(true, true, AstronautInfo["user_name"].ToString(), AstronautInfo["name"].ToString(), "Astronaut");
                    this.Close();
                    S.ShowDialog();
                }
            }));
        }

        #endregion

        #endregion

        #region Cancel input

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            e.Handled = true;
        }

        #endregion
    }
}
