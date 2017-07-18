using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Threading;
using Station.GUI.Actors;

namespace Station.GUI
{
    public partial class Main : Window
    {
        Classes.Person person = new Classes.Person();
        Classes.News News;
        Classes.Input I = new Classes.Input();

        DispatcherTimer Timer;
        Data.DataAccessLayer Data = new Data.DataAccessLayer();

        #region Enums
        enum NewsActor
        {
            Doctor,
            Astronaut
        }

        enum loginAttr
        {
            user_name,
            name,
            jop
        }
        #endregion

        public Main()
        {
            InitializeComponent();

            News = new Classes.News(Slider, txtb_News, txtb_News2);

            News.selectNews(NewsActor.Doctor.ToString(), 1);
            News.selectNews(NewsActor.Astronaut.ToString(), 1);
            News.GetNews(null, null);

            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 5);
            Timer.Tick += News.GetNews;
            Timer.Start();
        }

        #region Login
        private void btn_login_Click(object sender, RoutedEventArgs e)
        {

            string userName, Name, Jop;

            DataRow dt = person.login(txt_userName.Text, txt_password.Password);

            if (dt != null)
            {
                userName = dt[loginAttr.user_name.ToString()].ToString();
                Name = dt[loginAttr.name.ToString()].ToString();
                Jop = dt[loginAttr.jop.ToString()].ToString();

                if (Jop != "Admin")
                    person.access(true, true, userName, Name, Jop);
                Timer.Stop();

                switch (Jop)
                {
                    case "Astronaut":
                        {
                            Astronaut A = new Astronaut(dt);
                            A.Show();
                            this.Close();
                        }
                        break;
                    case "Engineer":
                        {
                            Engineer E = new Engineer(dt);
                            E.Show();
                            this.Close();
                        }
                        break;
                    case "Employee":
                        {
                            Employee E = new Employee(dt);
                            E.Show();
                            this.Close();
                        }
                        break;
                    case "Security":
                        {
                            Security S = new Security(dt);
                            S.Show();
                            this.Close();
                        }
                        break;
                    case "Doctor":
                        {
                            Doctor D = new Doctor(dt);
                            D.Show();
                            this.Close();
                        }
                        break;
                    case "Support":
                        {
                            Support S = new Support(dt);
                            S.Show();
                            this.Close();
                        }
                        break;
                    case "Admin":
                        {
                            Admin A = new Admin(dt);
                            A.Show();
                            this.Close();
                        }
                        break;
                    default:
                        MessageBox.Show("Error!", "Error", MessageBoxButton.OK, MessageBoxImage.Error); break;
                }
            }
            else
            {
                if (txt_userName.Text.Length > 0 && txt_password.Password.Length > 0)
                {
                    person.access(false, false, txt_userName.Text, "", "");
                    MessageBox.Show("User Name or Password isn't correct\n Please try again", "Invalid Login", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    if (txt_userName.Text.Length == 0)
                        UN_Hint.Visibility = Visibility.Visible;
                    if (txt_password.Password.Length == 0)
                        Pass_Hint.Visibility = Visibility.Visible;
                }
            }
        }
        #endregion

        #region Register
        private void btn_register_Click(object sender, RoutedEventArgs e)
        {
            Register R = new Register();
            R.ShowDialog();
        }
        #endregion

        #region When User Name Or Password Text Changed

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtUserName.Visibility = (txt_userName.Text.Length > 0 ? Visibility.Hidden : Visibility.Visible);
            if (UN_Hint.Visibility == Visibility.Visible)
                UN_Hint.Visibility = Visibility.Hidden;
        }

        private void txt_password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtPassword.Visibility = (txt_password.Password.Length > 0 ? Visibility.Hidden : Visibility.Visible);
            if (Pass_Hint.Visibility == Visibility.Visible)
                Pass_Hint.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Input accept only charcters and numbers
        private void txt_userName_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            I.NumbersCharcters(sender, e);
        }
        #endregion
    }
}
