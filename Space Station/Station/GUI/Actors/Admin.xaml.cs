using System;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace Station.GUI.Actors
{
    public partial class Admin : Window
    {
        Classes.Admin A = new Classes.Admin();
        Classes.Options Op;

        DataTable dt;

        string UserName, AUserName;

        public Admin(DataRow Info)
        {
            InitializeComponent();

            txt_Name.Text = Info["name"].ToString();
            UserName = Info["user_name"].ToString();

            if (Info["photo"] != DBNull.Value)
                Photo.ImageSource = Classes.Person.ByteToImage((byte[])Info["photo"]);

            Actors("");

            Op = new Classes.Options(Options);
        }

        #region (Add - Delete - Restart - Shut Down) Buttons

        #region Add

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            txt_Code.Clear();
            if (cmb_Add.SelectedIndex != -1)
                txt_Code.Text = A.add(cmb_Add.Text);
            else
                MessageBox.Show("Please Select a Jop", "", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #endregion

        #region Delete

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (AUserName != "")
            {
                A.delete(AUserName);
                Actors("");
                MessageBox.Show("Done !");
            }
            else
                MessageBox.Show("Please Select a Person !");
        }

        #endregion

        #region Restart

        private void btn_Restart_Click(object sender, RoutedEventArgs e)
        {
            A.restart();
        }

        #endregion

        #region Shut Down

        private void btn_ShutDown_Click(object sender, RoutedEventArgs e)
        {
            A.shutdown();
        }

        #endregion

        #endregion

        #region Search Text Changed

        private void Search_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            AUserName = "";
            if (Search.Text.Length > 0)
            {
                Hint.Visibility = Visibility.Hidden;
                Actors(Search.Text);
            }
            else
            {
                Hint.Visibility = Visibility.Visible;
                Actors("");
            }
        }

        #endregion

        #region LV Selection Changed

        private void LV_Actors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            for (int i = 0; i < LV_Actors.Items.Count; i++)
            {
                if (LV_Actors.Items[i] == LV_Actors.SelectedItem)
                {
                    AUserName = ((Classes.AdminItem)LV_Actors.Items[i]).UserName;
                }
            }
        }

        #endregion

        #region Actors Method

        private void Actors(string Search)
        {
            LV_Actors.Items.Clear();
            dt = A.GetActors(UserName, Search);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LV_Actors.Items.Add(new Classes.AdminItem
                {
                    UserName = dt.Rows[i]["user_name"].ToString(),
                    Name = dt.Rows[i]["name"].ToString(),
                    Phone = dt.Rows[i]["phone"].ToString(),
                    Jop = dt.Rows[i]["jop"].ToString(),
                    Address = dt.Rows[i]["address"].ToString()
                });
            }
        }

        #endregion

        #region (Logout - open/close) MouseDown Events

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
            M.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Main M = new Main();
            this.Close();
            M.ShowDialog();
        }

        #endregion
    }
}
