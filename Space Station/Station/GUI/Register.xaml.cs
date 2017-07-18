using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace Station.GUI
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        Data.DataAccessLayer Data = new Data.DataAccessLayer();
        Classes.Input I = new Classes.Input();
        Thread thread;
        bool CheckUN = false;

        #region Register Button
        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            if (txt_UserName.Text.Length > 0)
            {
                if (CheckUN)
                {
                    if (txt_Name.Text.Length > 0)
                    {
                        if (txt_Password.Password.Length > 0)
                        {
                            Classes.Person P = new Classes.Person();

                            P.register(Classes.Person.ImageToByte((BitmapSource)Photo.ImageSource), txt_UserName.Text, txt_Name.Text, txt_Password.Password, txt_Jop.Text, txt_Address.Text, txt_Phone.Text);
                            Remove();
                            System.Windows.Forms.MessageBox.Show("Registration successfully", "Congratulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            Pass_Hint.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        Name_Hint.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("This user name is reserved!", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    UN_Validate.Visibility = Visibility.Hidden;
                    Pass_Hint.Visibility = Visibility.Hidden;
                    Name_Hint.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                UN_Hint.Visibility = Visibility.Visible;
            }
        }
        #endregion

        #region Check Methods

        #region Check ID
        public void check()
        {
            SqlParameter[] param = { new SqlParameter("@ID", SqlDbType.NVarChar, 15) };
            txt_Code.Dispatcher.Invoke(new MethodInvoker(delegate { param[0].Value = txt_Code.Text; }));

            DataTable dt = Data.selectData("select_ID", param);

            if (dt.Rows.Count == 1)
            {
                txt_Jop.Dispatcher.Invoke(new MethodInvoker(delegate
                {
                    txt_Code.IsEnabled = false;
                    txt_Jop.Text = dt.Rows[0]["Jop"].ToString();
                    Stack_Info.IsEnabled = true;
                    btn_Register.IsEnabled = true;
                }
                ));
            }
            else
            {
                txt_Jop.Dispatcher.Invoke(new MethodInvoker(delegate { txt_Jop.Text = ""; }));
            }
            thread.Abort();
        }
        #endregion

        #region Check User Name
        public void checkUser(string userName)
        {
            SqlParameter[] param = { new SqlParameter("@user_name", SqlDbType.NVarChar, 50) };
            param[0].Value = userName;

            DataTable dt = Data.selectData("select_user_name", param);

            UN_Validate.Dispatcher.Invoke(new MethodInvoker(delegate
            {
                if (dt.Rows.Count != 0)
                {
                    CheckUN = false;
                    UN_Validate.Source = new BitmapImage(new Uri(@"/Station;component/Resources/Wrong 3.png", UriKind.RelativeOrAbsolute));
                }
                else
                {
                    CheckUN = true;
                    UN_Validate.Source = new BitmapImage(new Uri(@"/Station;component/Resources/Correct 2.png", UriKind.RelativeOrAbsolute));
                }
            }));

        }
        #endregion

        #endregion

        #region Remove Code
        void Remove()
        {
            SqlParameter param = new SqlParameter("@ID", SqlDbType.NVarChar, 15);
            param.Value = txt_Code.Text;
            Data.ExecuteCommand("Delete_ID", param);
        }
        #endregion

        #region Text Changed Events
        private void txt_Code_TextChanged(object sender, TextChangedEventArgs e)
        {
            thread = new Thread(check);

            Code.Visibility = (txt_Code.Text.Length > 0 ? Visibility.Hidden : Visibility.Visible);

            if (txt_Code.Text.Length == 10)
                thread.Start();
        }

        private void txt_UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (UN_Hint.Visibility == Visibility.Visible)
                UN_Hint.Visibility = Visibility.Hidden;

            if (txt_UserName.Text.Length > 0)
            {
                string userName = txt_UserName.Text;
                UN_Validate.Visibility = Visibility.Visible;
                thread = new Thread(() => checkUser(userName));
                thread.Start();
            }
            else
                UN_Validate.Visibility = Visibility.Hidden;
        }

        private void txt_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Name_Hint.Visibility == Visibility.Visible)
                Name_Hint.Visibility = Visibility.Hidden;
        }

        private void txt_Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Pass_Hint.Visibility == Visibility.Visible)
                Pass_Hint.Visibility = Visibility.Hidden;
        }
        #endregion

        #region Selcet Image
        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images| *.JPG; *.PNG";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImageSource image = new BitmapImage(new Uri(ofd.FileName, UriKind.Absolute));
                Photo.ImageSource = image;
            }
        }
        #endregion

        #region Accept Only Numbers
        private void txt_Code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }
        #endregion

        #region When Touch Leave User Name TB
        private void txt_UserName_TouchLeave(object sender, TouchEventArgs e)
        {
            thread.Abort();
        }
        #endregion

        #region Accept characters only / Characters and numbers

        private void txt_UserName_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            I.Chracters(sender, e);
        }

        private void txt_Password_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            I.NumbersCharcters(sender, e);
        }

        #endregion

        #region Back Button
        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
