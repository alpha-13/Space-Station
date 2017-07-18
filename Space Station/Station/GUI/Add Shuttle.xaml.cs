using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Shuttle.Classes;

namespace Station.GUI
{
    public partial class Add_Shuttle : Window
    {
        string UserName;
        bool[] Checking = new bool[4];

        Classes.Astronaut A = new Classes.Astronaut();
        Classes.Input I = new Classes.Input();
        SpaceShuttle Shuttle = new SpaceShuttle();

        public Add_Shuttle(string UserName)
        {
            InitializeComponent();
            this.UserName = UserName;
            Date.SelectedDate = DateTime.Now.Date.AddDays(30);
        }

        #region (Add - Cancel) Buttons

        #region Add
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Name.Text.Length > 0)
            {
                if (Checking[0])
                {
                    if (txt_UserName.Text.Length > 0)
                    {
                        if (Checking[1])
                        {
                            if (Password.Password.Length > 0)
                            {
                                if (txt_Destination.Text.Length > 0)
                                {
                                    if (Checking[2])
                                    {
                                        if (txt_Fuel.Text.Length > 0)
                                        {
                                            if (Checking[3])
                                            {
                                                TimeSpan TS = Date.SelectedDate.Value - DateTime.Now.Date;
                                                if (TS.Days >= 30)
                                                {
                                                    string[] info = new string[6];
                                                    info[0] = txt_Name.Text;
                                                    info[1] = UserName;
                                                    info[2] = txt_UserName.Text;
                                                    info[3] = Password.Password;
                                                    info[4] = txt_Destination.Text;
                                                    info[5] = new TextRange(rtb_Notes.Document.ContentStart, rtb_Notes.Document.ContentEnd).Text;

                                                    int Stages = Convert.ToInt32(txt_Stages.Text);
                                                    double Fuel = Convert.ToDouble(txt_Fuel.Text);
                                                    A.addShuttleMission(Stages, Fuel, Convert.ToInt32(txt_Code.Text), Date.SelectedDate.Value.Date, info);
                                                    MessageBox.Show("Mission Added Successfuly");
                                                    this.Close();
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Fuel_Hint.Visibility = Visibility.Visible;
                                        }
                                    }
                                }
                                else
                                {
                                    Destination_Hint.Visibility = Visibility.Visible;
                                }
                            }
                            else
                            {
                                Pass_Hint.Visibility = Visibility.Visible;
                            }
                        }
                    }
                    else
                    {
                        UN_Hint.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                Name_Hint.Visibility = Visibility.Visible;
            }
        }
        #endregion

        #region Cancel
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion

        #region Checking

        #region Check (Code - UserName)
        private void txt_Code_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_Code.Text.Length > 0)
                if (A.CheckShuttleCode(UserName, txt_Code.Text))
                {
                    txt_Code.Background = Brushes.Green;
                    txt_Code.IsEnabled = false;
                    btn_Add.IsEnabled = true;
                    Details.IsEnabled = true;
                }
                else
                {
                    txt_Code.Background = Brushes.Red;
                    Details.IsEnabled = false;
                }
            else
                txt_Code.Background = Brushes.Transparent;
        }
        #endregion

        #region Check Name
        private void txt_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_Name.Text.Length > 0)
            {
                Name_Hint.Visibility = Visibility.Hidden;
                if (A.CheckShuttleName(UserName, txt_Name.Text).Rows.Count > 0)
                    ShowMessage(Check, false, 0);
                else
                    ShowMessage(Check, true, 0);
            }
            else
            {
                Check.Visibility = Visibility.Hidden;
                Checking[0] = false;
            }
        }
        #endregion

        #region Check UserName
        private void txt_UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_UserName.Text.Length > 0)
            {
                UN_Hint.Visibility = Visibility.Hidden;
                if (Shuttle.checkSuttleUserName(UserName, txt_UserName.Text).Rows.Count > 0)
                    ShowMessage(UName, false, 1);
                else
                    ShowMessage(UName, true, 1);
            }
            else
            {
                UName.Visibility = Visibility.Hidden;
                Checking[1] = false;
            }
        }
        #endregion

        #region Check Destination if >100,000 and <600,000
        private void txt_Destination_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txt_Destination.Text.Length > 0)
                {
                    Destination_Hint.Visibility = Visibility.Hidden;
                    if (Convert.ToInt32(txt_Destination.Text) >= 100000 && Convert.ToInt32(txt_Destination.Text) <= 600000)
                        ShowMessage(Destination, true, 2);
                    else
                        ShowMessage(Destination, false, 2);
                }
                else
                {
                    Destination.Visibility = Visibility.Hidden;
                    Checking[2] = false;
                }
            }
            catch
            {
                ShowMessage(Destination, false, 2);
            }
        }
        #endregion

        #region Check Fuel if > Destination/3
        private void txt_Fuel_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txt_Fuel.Text.Length > 0)
                {
                    Fuel_Hint.Visibility = Visibility.Hidden;
                    if (Convert.ToInt32(txt_Fuel.Text) >= Convert.ToInt32(txt_Destination.Text) / 3)
                        ShowMessage(Fuel, true, 3);
                    else
                        ShowMessage(Fuel, false, 3);
                }
                else
                {
                    Fuel.Visibility = Visibility.Hidden;
                    Checking[3] = false;
                }
            }
            catch
            {
                ShowMessage(Fuel, false, 3);
            }
        }
        #endregion

        #region Password
        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Pass_Hint.Visibility == Visibility.Visible)
                Pass_Hint.Visibility = Visibility.Hidden;
        }
        #endregion

        #endregion

        #region Input

        #region Accept Only Numbers (0 => 9)
        private void txt_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            I.Numbers(sender, e);
        }
        #endregion

        #region Accept Characters And Numbers (a => z - A => Z - 0 => 9)
        private void Password_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            I.NumbersCharcters(sender, e);
        }
        #endregion

        #endregion

        #region Method for  showing image validation
        private void ShowMessage(Image I, bool State, byte index)
        {
            if (State)
                I.Source = new BitmapImage(new Uri(@"/Station;component/Resources/Correct 2.png", UriKind.RelativeOrAbsolute));
            else
                I.Source = new BitmapImage(new Uri(@"/Station;component/Resources/Wrong 3.png", UriKind.RelativeOrAbsolute));

            I.Visibility = Visibility.Visible;
            Checking[index] = State;
        }
        #endregion
    }
}
