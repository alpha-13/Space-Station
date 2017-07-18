using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.Timers;
using Station.Classes;
using Shuttle.Classes;

namespace Station.GUI.Actors
{
    public partial class Astronaut : Window
    {
        string UserName, SearchText;

        Options Op;

        Timer myTimer = new Timer();

        Person P = new Person();
        Information Information = new Information();
        SpaceShuttle Shuttle = new SpaceShuttle();

        Galaxy Galaxy = new Galaxy();
        PlanetarySystem PS = new PlanetarySystem();
        Plant Plant = new Plant();

        DataRow Info;
        DataTable Pdt = new DataTable();
        DataTable PSdt = new DataTable();
        DataTable Gdt = new DataTable();

        public Astronaut(DataRow Info)
        {
            InitializeComponent();

            this.Info = Info;
            txt_Name.Text = Info["name"].ToString();
            UserName = Info["user_name"].ToString();

            Op = new Options(Options);

            if (Info["photo"] != DBNull.Value)
                Photo.ImageSource = Person.ByteToImage((byte[])Info["photo"]);

            if (!(Shuttle.getInformation("Galaxy", UserName).Rows.Count == 0
                && Shuttle.getInformation("planetary", UserName).Rows.Count == 0
                && Shuttle.getInformation("Plant", UserName).Rows.Count == 0))
            {
                ShowInfo(null, null);
                myTimer.Elapsed += new ElapsedEventHandler(ShowInfo);
                myTimer.Interval = 5000;
                myTimer.Enabled = true;
            }
        }

        #region (Add - Login - Reporting - Contact - Launch) Buttons

        private void Add_Shuttle_Click(object sender, RoutedEventArgs e)
        {
            Add_Shuttle S = new Add_Shuttle(UserName);
            S.ShowDialog();
        }

        private void Decision_Click(object sender, RoutedEventArgs e)
        {
            Decisions D = new Decisions(UserName, txt_Name.Text, "Astronaut");
            D.ShowDialog();
        }

        private void Login_Shuttle_Click(object sender, RoutedEventArgs e)
        {
            Login_Shuttle L = new Login_Shuttle(UserName);
            L.ShowDialog();

            if (L.IsOpened)
            {
                Space_Shuttle SS = new Space_Shuttle(Info, L.ShuttleUserName.Text, L.ShuttleName);
                L.Close();
                SS.Show();
                this.Close();
            }
            else
                L.Close();
        }

        private void Reporting_Click(object sender, RoutedEventArgs e)
        {
            Reporting R = new Reporting(UserName, txt_Name.Text);
            R.ShowDialog();
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            Contact C = new Contact(UserName);
            C.ShowDialog();
        }

        private void Launch_Click(object sender, RoutedEventArgs e)
        {
            Second_Login SL = new Second_Login(Info);
            SL.ShowDialog();

            if (SL.Login)
            {
                this.Close();
                Main M = new Main();
                M.Show();
                SL.L.ShowDialog();
                SL.Close();
            }
        }

        #endregion

        #region Events

        #region Show Information

        private void ShowInfo(object source, ElapsedEventArgs e)
        {
            DataTable dt = Shuttle.getInformation("Galaxy", UserName);
            if (dt.Rows.Count > 0)
                Information.GalaxyInformation(Galaxy_Info, dt.Rows[0], GImage,
                    Gtxt_Name, Gtxt_Age, Gtxt_Type, Gtxt_Diameter, Gtxt_Stars, Gtxt_Arams, Gtxt_Mass, Gtxt_Expansion, Gtxt_Density);

            dt = Shuttle.getInformation("planetary", UserName);
            if (dt.Rows.Count > 0)
                Information.PlanetarySystemInfo(Planetary_Info, dt.Rows[0], PSImage,
                    PStxt_Galaxy, PStxt_Name, PStxt_Plants, PStxt_Asteroids, PStxt_Location, PStxt_Speed);

            dt = Shuttle.getInformation("Plant", UserName);
            if (dt.Rows.Count > 0)
                Information.PlantInformation(plant_Info, dt.Rows[0], PImage,
                    ptxt_PlanetarySystem, ptxt_Name, ptxt_Water, ptxt_Tempreture, ptxt_Live, ptxt_Year, ptxt_Moons, ptxt_Oxygen, ptxt_CO2, ptxt_Nitro);
        }

        #endregion

        #region Search (Galaxy - Planetary - Plant)
        private void txt_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_Search.Text.Length > 0)
            {
                Search.Visibility = Visibility.Hidden;
                LV_Search.Items.Clear();
                SearchText = (txt_Search.Text == "*" ? "" : txt_Search.Text);

                if (CB_Galaxy.IsChecked == true)
                {
                    Gdt = Galaxy.SelectInformation(false, SearchText, UserName, "");
                    if (Gdt.Rows.Count > 0)
                        for (int i = 0; i < Gdt.Rows.Count; i++)
                            LV_Search.Items.Add(new MyItem { Name = Gdt.Rows[i]["Name"].ToString(), Type = "Galaxy" });
                }

                if (CB_PS.IsChecked == true)
                {
                    PSdt = PS.SelectInformation(false, SearchText, UserName, "");
                    if (PSdt.Rows.Count > 0)
                        for (int i = 0; i < PSdt.Rows.Count; i++)
                            LV_Search.Items.Add(new MyItem { Name = PSdt.Rows[i]["Name"].ToString(), Type = "Planetary" });
                }

                if (CB_Plant.IsChecked == true)
                {
                    Pdt = Plant.SelectInformation(false, SearchText, UserName, "");
                    if (Pdt.Rows.Count > 0)
                        for (int i = 0; i < Pdt.Rows.Count; i++)
                            LV_Search.Items.Add(new MyItem { Name = Pdt.Rows[i]["Name"].ToString(), Type = "Plant" });
                }
            }
            else
            {
                Search.Visibility = Visibility.Visible;
                LV_Search.Items.Clear();
                myTimer.Enabled = true;
            }
        }
        #endregion

        #endregion

        #region When Search Item Selected

        private void LV_Search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < LV_Search.Items.Count; i++)
            {
                var selectedItem = (dynamic)LV_Search.SelectedItem;
                if (LV_Search.Items[i] == LV_Search.SelectedItem)
                {
                    myTimer.Enabled = false;
                    if (selectedItem.Type == "Plant")
                    {
                        Information.PlantInformation(plant_Info, Pdt.Rows[i - Gdt.Rows.Count - PSdt.Rows.Count], PImage, ptxt_PlanetarySystem, ptxt_Name, ptxt_Water, ptxt_Tempreture, ptxt_Live, ptxt_Year, ptxt_Moons, ptxt_Oxygen, ptxt_CO2, ptxt_Nitro);
                    }
                    else if (selectedItem.Type == "Planetary")
                    {
                        Information.PlanetarySystemInfo(Planetary_Info, PSdt.Rows[i - Gdt.Rows.Count], PSImage, PStxt_Galaxy, PStxt_Name, PStxt_Plants, PStxt_Asteroids, PStxt_Location, PStxt_Speed);
                    }
                    else if (selectedItem.Type == "Galaxy")
                    {
                        Information.GalaxyInformation(Galaxy_Info, Gdt.Rows[i], GImage, Gtxt_Name, Gtxt_Age, Gtxt_Type, Gtxt_Diameter, Gtxt_Stars, Gtxt_Arams, Gtxt_Mass, Gtxt_Expansion, Gtxt_Density);
                    }
                }
            }
        }

        #endregion

        #region (Edit Info - Logout - open/close) MouseDown Events

        private void Ellipse_Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Op.Show();
        }

        private void EditInfo_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Edit_Information EI = new Edit_Information(UserName);
            Op.Show();
            EI.ShowDialog();
        }

        private void Logout_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Main M = new Main();
            this.Close();
            P.logout(UserName);
            M.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            P.logout(UserName);
            myTimer.Enabled = false;
            Op.Close();
        }

        #endregion

        #region Check Boxes

        private void CB_Plant_Click(object sender, RoutedEventArgs e)
        {
            if (CB_Plant.IsChecked == true)
                txt_Search_TextChanged(null, null);
        }

        private void CB_PS_Click(object sender, RoutedEventArgs e)
        {
            if (CB_PS.IsChecked == true)
                txt_Search_TextChanged(null, null);
        }

        private void CB_Galaxy_Click(object sender, RoutedEventArgs e)
        {
            if (CB_Galaxy.IsChecked == true)
                txt_Search_TextChanged(null, null);
        }

        #endregion
    }
}
