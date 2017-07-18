using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Station.Classes;
using System.Data;

namespace Station.GUI
{
    public partial class Login_Shuttle : Window
    {
        string UserName;
        public bool IsOpened { set; get; }
        public string ShuttleName { set; get; }
        Input I = new Input();

        public Login_Shuttle(string UserName)
        {
            InitializeComponent();

            this.UserName = UserName;
        }

        #region (Login - Cancel) Buttons

        #region Login
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (ShuttleUserName.Text.Length > 0)
                if (ShuttlePassword.Password.Length > 0)
                {
                    Astronaut A = new Astronaut();
                    DataTable dt = A.Login_Shuttle(ShuttleUserName.Text, ShuttlePassword.Password, UserName);
                    if (dt.Rows.Count == 1)
                    {
                        this.Hide();
                        IsOpened = true;
                        ShuttleName = dt.Rows[0]["name"].ToString();
                    }
                    else
                        MessageBox.Show("User Name or password is not correct !", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    Pass_Hint.Visibility = Visibility.Visible;
            else
                Name_Hint.Visibility = Visibility.Visible;

        }
        #endregion

        #region Cancel Button
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion

        #region Input

        private void ShuttleUserName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            I.NumbersCharcters(sender, e);
        }

        private void ShuttlePassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            I.NumbersCharcters(sender, e);
        }

        #endregion

        #region When Text Changed

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            Name_Hint.Visibility = Visibility.Hidden;
        }

        private void ShuttlePassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Pass_Hint.Visibility = Visibility.Hidden;
        }

        #endregion
    }
}
