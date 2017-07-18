using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Shuttle.Classes;
using System.Data;
using System.Windows.Forms;
using Station.Classes;

namespace Station.GUI
{
    public partial class Space_Shuttle : Window
    {
        string ShuttleName, ShuttleUserName, UserName, Message;
        string ImagePath = @"/Station;component/Resources/image.png";
        string WrongPath = @"/Station;component/Resources/Wrong 3.png";
        string CorrectPath = @"/Station;component/Resources/Correct 2.png";

        bool GName, PSName, PName, MName;

        Options op;
        Input I, IG, IPS, IP, IM, IN;

        Person Per = new Person();
        Astronaut A = new Classes.Astronaut();
        Galaxy G = new Galaxy();
        PlanetarySystem PS = new PlanetarySystem();
        Plant P = new Plant();

        OpenFileDialog ofd = new OpenFileDialog();

        DataTable dt = new DataTable();
        DataRow Info;

        #region Space_Shuttle Constractor

        public Space_Shuttle(DataRow Info, string ShuttleUserName, string ShuttleName)
        {
            InitializeComponent();

            this.Info = Info;
            this.ShuttleName = ShuttleName;
            this.ShuttleUserName = ShuttleUserName;

            txt_Name.Text = Info["name"].ToString();
            UserName = Info["user_name"].ToString();

            if (Info["photo"] != DBNull.Value)
                Photo.ImageSource = Classes.Person.ByteToImage((byte[])Info["photo"]);

            Per.access(true, true, UserName, txt_Name.Text, "Astronaut");

            op = new Options(Options);

            I = new Input();
            IG = new Input(txt_Message);
            IPS = new Input(txt_MessagePS);
            IP = new Input(txt_MessageP);
            IM = new Input(txt_MessageMission);
            IN = new Input(txt_MessageNews);

            GetMissions();

            Get_Planetary_Plant();

            GImage.Source = new BitmapImage(new Uri(ImagePath, UriKind.Relative));
            PSImage.Source = new BitmapImage(new Uri(ImagePath, UriKind.Relative));
            PImage.Source = new BitmapImage(new Uri(ImagePath, UriKind.Relative));

            MissionStart.SelectedDate = DateTime.Now.Date.AddDays(1);
            MissionEnd.SelectedDate = DateTime.Now.Date.AddDays(2);
        }

        #endregion

        #region Buttons

        #region Add Galaxy

        private void btn_AddGalaxy_Click(object sender, RoutedEventArgs e)
        {
            if (Gtxt_Name.Text.Length > 0)
                if (GName)
                    if (Gtxt_Age.Text.Length > 0)
                        if (Gtxt_Type.Text.Length > 0)
                            if (Gtxt_Diameter.Text.Length > 0)
                                if (Gtxt_Stars.Text.Length > 0)
                                    if (Gtxt_Arms.Text.Length > 0)
                                        if (Gtxt_Mass.Text.Length > 0)
                                            if (Gtxt_Mass.Text.Length > 0)
                                                if (Gtxt_Expansion.Text.Length > 0)
                                                    if (Gtxt_Density.Text.Length > 0)
                                                    {
                                                        G.sendInformation(Classes.Person.ImageToByte((BitmapImage)GImage.Source), new TextRange(G_Description.Document.ContentStart, G_Description.Document.ContentEnd).Text,
                                                                            ShuttleUserName, Gtxt_Name.Text, UserName, Gtxt_Age.Text, Gtxt_Type.Text, Gtxt_Diameter.Text, Gtxt_Stars.Text, Gtxt_Arms.Text, Gtxt_Mass.Text, Gtxt_Expansion.Text, Gtxt_Density.Text);
                                                        btn_ClearGalaxy_Click(null, null);
                                                        Get_Planetary_Plant();
                                                        Message = "Galaxy Saved Successfully";
                                                    }
                                                    else
                                                        Message = "Enter Galaxy Density";
                                                else
                                                    Message = "Enter Galaxy Expansion";
                                            else
                                                Message = "Enter Galaxy Mass";
                                        else
                                            Message = "Enter Galaxy Arms";
                                    else
                                        Message = "Enter Galaxy Arms";
                                else
                                    Message = "Enter Galaxy Stars";
                            else
                                Message = "Enter Galaxy Diameter";
                        else
                            Message = "Enter Galaxy Type";
                    else
                        Message = "Enter Galaxy Age";
                else
                    Message = "Galaxy name already saved before !";
            else
                Message = "Please Enter Galaxy Name !";
            IG.Message(Message);
        }

        #endregion

        #region Add Planetary System

        private void btn_AddPS_Click(object sender, RoutedEventArgs e)
        {
            if (PStxt_Name.Text.Length > 0)
                if (PSName)
                    if (PStxt_Plants.Text.Length > 0)
                        if (PStxt_Asteroids.Text.Length > 0)
                            if (PStxt_Location.Text.Length > 0)
                                if (PStxt_Speed.Text.Length > 0)
                                {
                                    PS.sendInformation(Classes.Person.ImageToByte((BitmapImage)PSImage.Source), new TextRange(PS_Desc.Document.ContentStart, PS_Desc.Document.ContentEnd).Text,
                                                        ShuttleUserName, PStxt_Name.Text, PStxt_Galaxy.Text, UserName, PStxt_Plants.Text, PStxt_Asteroids.Text, PStxt_Location.Text, PStxt_Speed.Text);
                                    btn_ClearPS_Click(null, null);
                                    Get_Planetary_Plant();
                                    Message = "Planetary Saved Successfully";
                                }
                                else
                                    Message = "Enter Planetary Speed";
                            else
                                Message = "Enter Planetary Location";
                        else
                            Message = "Enter Planetary Asteroids";
                    else
                        Message = "Enter Planetary Plants";
                else
                    Message = "This Planetary name already saved before !";
            else
                Message = "Please Enter Planetary Name !";
            IPS.Message(Message);
        }

        #endregion

        #region Add Plant

        private void btn_AddPlant_Click(object sender, RoutedEventArgs e)
        {
            if (ptxt_Name.Text.Length > 0)
                if (PName)
                    if (ptxt_Water.Text.Length > 0)
                        if (ptxt_Tempreture.Text.Length > 0)
                            if (ptxt_Live.Text.Length > 0)
                                if (ptxt_Year.Text.Length > 0)
                                    if (ptxt_Moons.Text.Length > 0)
                                        if (ptxt_Oxygen.Text.Length > 0)
                                            if (ptxt_CO2.Text.Length > 0)
                                                if (ptxt_Nitro.Text.Length > 0)
                                                {
                                                    P.sendInformation(Classes.Person.ImageToByte((BitmapImage)PImage.Source), new TextRange(P_Desc.Document.ContentStart, P_Desc.Document.ContentEnd).Text,
                                                                        ShuttleUserName, ptxt_PlanetarySystem.Text, UserName, ptxt_Name.Text, ptxt_Water.Text, ptxt_Tempreture.Text, ptxt_Live.Text, ptxt_Year.Text, ptxt_Moons.Text, ptxt_Oxygen.Text, ptxt_CO2.Text, ptxt_Nitro.Text);
                                                    btn_ClearPlant_Click(null, null);
                                                    Message = "Plant Saved Successfully";
                                                }
                                                else
                                                    Message = "Enter Plant Nitrogen";
                                            else
                                                Message = "Enter Plant Carbon Dioxide";
                                        else
                                            Message = "Enter Plant Oxygen";
                                    else
                                        Message = "Enter Plant Moons";
                                else
                                    Message = "Enter Plant Year";
                            else
                                Message = "Enter Plant Live";
                        else
                            Message = "Enter Plant Tempreture";
                    else
                        Message = "Enter Plant Water";
                else
                    Message = "This Plant name already saved before !";
            else
                Message = "Please Enter Plant Name !";

            IP.Message(Message);
        }

        #endregion

        #region Add Mission

        private void btn_AddMission_Click(object sender, RoutedEventArgs e)
        {
            if (MissionName.Text.Length > 0)
                if (MName)
                    if ((MissionStart.SelectedDate.Value > DateTime.Now.Date) && MissionEnd.SelectedDate.Value > MissionStart.SelectedDate.Value)
                    {
                        bool flag = true;
                        for (int i = 0; i < LVMissions.Items.Count; i++)
                        {
                            var Item = (dynamic)LVMissions.Items[i];
                            if (((MissionStart.SelectedDate.Value >= Convert.ToDateTime(Item.Start)) && (MissionStart.SelectedDate.Value <= Convert.ToDateTime(Item.End)))
                                || ((MissionEnd.SelectedDate.Value >= Convert.ToDateTime(Item.Start)) && (MissionEnd.SelectedDate.Value <= Convert.ToDateTime(Item.End))))
                            {
                                flag = false;
                                break;
                            }
                        }

                        if (flag)
                        {
                            A.AddMission(ShuttleName, MissionName.Text, UserName, MissionStart.SelectedDate.Value, MissionEnd.SelectedDate.Value, new TextRange(Description.Document.ContentStart, Description.Document.ContentEnd).Text);
                            LVMissions.Items.Clear();
                            MissionDescription.Document.Blocks.Clear();
                            GetMissions();

                            MissionName.Clear();
                            MissionStart.SelectedDate = DateTime.Now.Date.AddDays(1);
                            MissionEnd.SelectedDate = DateTime.Now.Date.AddDays(2);
                            Description.Document.Blocks.Clear();

                            Message = "Mission Added Successfully !";
                        }
                        else
                            Message = "THis Date Is Reseved";

                    }
                    else
                        Message = "Start Date Must Greater Than End Date And Current Date";
                else
                    Message = "Mission Name Reseved";
            else
                Message = "Please Enter Mission Name !";

            IM.Message(Message);
        }

        #endregion

        #region Add News

        private void btnAddNews_Click(object sender, RoutedEventArgs e)
        {
            if (News.Text.Length > 0)
            {
                A.News(News.Text);
                Message = "News Added Successfully!";
            }
            else
                Message = "Please Enter News !";

            IN.Message(Message);
            News.Clear();
        }

        #endregion

        #region Clear Galaxy

        private void btn_ClearGalaxy_Click(object sender, RoutedEventArgs e)
        {
            Gtxt_Name.Clear();
            Gtxt_Age.Clear();
            Gtxt_Type.Clear();
            Gtxt_Type.Clear();
            Gtxt_Diameter.Clear();
            Gtxt_Stars.Clear();
            Gtxt_Arms.Clear();
            Gtxt_Mass.Clear();
            Gtxt_Expansion.Clear();
            Gtxt_Density.Clear();
            G_Description.Document.Blocks.Clear();
            GImage.Source = new BitmapImage(new Uri(ImagePath, UriKind.Relative));
        }

        #endregion

        #region Clear Planetary System

        private void btn_ClearPS_Click(object sender, RoutedEventArgs e)
        {
            PStxt_Galaxy.SelectedIndex = 0;
            PStxt_Name.Clear();
            PStxt_Plants.Clear();
            PStxt_Asteroids.Clear();
            PStxt_Location.Clear();
            PStxt_Speed.Clear();
            PS_Desc.Document.Blocks.Clear();
            GImage.Source = new BitmapImage(new Uri(ImagePath, UriKind.Relative));

        }

        #endregion

        #region Clear Plant

        private void btn_ClearPlant_Click(object sender, RoutedEventArgs e)
        {
            ptxt_PlanetarySystem.SelectedIndex = 0;
            ptxt_Name.Clear();
            ptxt_Water.Clear();
            ptxt_Tempreture.Clear();
            ptxt_Live.Clear();
            ptxt_Year.Clear();
            ptxt_Moons.Clear();
            ptxt_Oxygen.Clear();
            ptxt_CO2.Clear();
            ptxt_Nitro.Clear();
            P_Desc.Document.Blocks.Clear();
            GImage.Source = new BitmapImage(new Uri(ImagePath, UriKind.Relative));
        }

        #endregion

        #endregion

        #region Select (Galaxy - Planetary System - Plant) Image

        private void GImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GetImage(GImage);
        }

        private void PSImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GetImage(PSImage);
        }

        private void PImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GetImage(PImage);
        }

        #endregion

        #region Text Changed Events

        #region Galaxy Name

        private void Gtxt_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Gtxt_Name.Text.Length > 0)
            {
                G_Hint.Visibility = Visibility.Visible;
                if (G.SelectInformation(true, Gtxt_Name.Text, UserName, ShuttleUserName).Rows.Count > 0)
                {
                    G_Hint.Source = new BitmapImage(new Uri(WrongPath, UriKind.Relative));
                    GName = false;
                }
                else
                {
                    G_Hint.Source = new BitmapImage(new Uri(CorrectPath, UriKind.Relative));
                    GName = true;
                }
            }
            else
                G_Hint.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Planetary System Name

        private void PStxt_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PStxt_Name.Text.Length > 0)
            {
                PS_Hint.Visibility = Visibility.Visible;
                if (PS.SelectInformation(true, PStxt_Name.Text, UserName, ShuttleUserName).Rows.Count > 0)
                {
                    PS_Hint.Source = new BitmapImage(new Uri(WrongPath, UriKind.Relative));
                    PSName = false;
                }
                else
                {
                    PS_Hint.Source = new BitmapImage(new Uri(CorrectPath, UriKind.Relative));
                    PSName = true;
                }
            }
            else
                PS_Hint.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Plant Name

        private void ptxt_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ptxt_Name.Text.Length > 0)
            {
                P_Hint.Visibility = Visibility.Visible;
                if (P.SelectInformation(true, ptxt_Name.Text, UserName, ShuttleUserName).Rows.Count > 0)
                {
                    P_Hint.Source = new BitmapImage(new Uri(WrongPath, UriKind.Relative));
                    PName = false;
                }
                else
                {
                    P_Hint.Source = new BitmapImage(new Uri(CorrectPath, UriKind.Relative));
                    PName = true;
                }
            }
            else
                P_Hint.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Mission Name

        private void MissionName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (MissionName.Text.Length > 0)
            {
                CheckName.Visibility = Visibility.Visible;

                if (A.SelectMissions(true, ShuttleName, MissionName.Text).Rows.Count > 0)
                {
                    MName = false;
                    CheckName.Source = new BitmapImage(new Uri(WrongPath, UriKind.Relative));
                }
                else
                {
                    MName = true;
                    CheckName.Source = new BitmapImage(new Uri(CorrectPath, UriKind.Relative));
                }
            }
            else
                CheckName.Visibility = Visibility.Hidden;
        }

        #endregion

        #endregion

        #region Methods

        #region Get Missions

        private void GetMissions()
        {
            dt = A.SelectMissions(false, ShuttleName, "");
            LVMissions.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
                LVMissions.Items.Add(new Classes.MyItem2 { Name = dt.Rows[i]["Mission"].ToString(), Start = Convert.ToDateTime(dt.Rows[i]["Start_Time"]).ToString("dd/MM/yyyy"), End = Convert.ToDateTime(dt.Rows[i]["End_Time"]).ToString("dd/MM/yyyy") });
        }

        #endregion

        #region Get Image

        private void GetImage(Image I)
        {
            ofd.Filter = "Images| *.JPG; *.PNG";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImageSource image = new BitmapImage(new Uri(ofd.FileName, UriKind.Absolute));
                I.Source = image;
            }
        }

        #endregion

        #region Get Planetary / Plant and add them in List View

        private void Get_Planetary_Plant()
        {
            DataTable dt1 = G.SelectInformation(false, "", UserName, ShuttleUserName);
            DataTable dt2 = PS.SelectInformation(false, "", UserName, ShuttleUserName);

            PStxt_Galaxy.Items.Clear();
            ptxt_PlanetarySystem.Items.Clear();

            foreach (DataRow item in dt1.Rows)
                PStxt_Galaxy.Items.Add(item["name"].ToString());

            foreach (DataRow item in dt2.Rows)
                ptxt_PlanetarySystem.Items.Add(item["name"].ToString());

            if (PStxt_Galaxy.Items.Count > 0)
            {
                PSGrid.IsEnabled = true;
                PStxt_Galaxy.SelectedIndex = 0;
            }
            else
                PSGrid.IsEnabled = false;

            if (ptxt_PlanetarySystem.Items.Count > 0)
            {
                PGrid.IsEnabled = true;
                ptxt_PlanetarySystem.SelectedIndex = 0;
            }
            else
                PGrid.IsEnabled = false;
        }

        #endregion

        #endregion

        #region (Edit Info - Logout - Cancel - Window Closed) Events

        private void Ellipse_Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            op.Show();
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
            Per.logout(UserName);
            M.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Per.logout(UserName);
            op.Close();
        }

        #endregion

        #region LV Missions Selection Changed

        private void LVMissions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < LVMissions.Items.Count; i++)
            {
                if (LVMissions.Items[i] == LVMissions.SelectedItem)
                {
                    MissionDescription.Document.Blocks.Clear();
                    MissionDescription.Document.Blocks.Add(new Paragraph(new Run(dt.Rows[i]["Description"].ToString())));
                    break;
                }
            }
        }

        #endregion

        #region Input

        private void PreviewKeysDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            I.NumbersCharcters(sender, e);

            if (e.Key == Key.Space)
                e.Handled = false;
        }

        private void PreviewKeyDown_Charcters(object sender, System.Windows.Input.KeyEventArgs e)
        {
            I.Chracters(sender, e);
        }

        #endregion
    }
}
