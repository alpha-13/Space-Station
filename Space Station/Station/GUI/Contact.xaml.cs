using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Station.Classes;
using System.Data;

namespace Station.GUI
{
    public partial class Contact : Window
    {
        Input I = new Input();
        Person P = new Person();
        DataTable dt;
        string UserName;

        public Contact(string UserName)
        {
            InitializeComponent();

            this.UserName = UserName;
        }

        #region Text Search Changed

        private void txt_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LV_Search.Items.Clear();

            if (txt_Search.Text.Length > 0)
            {
                Search.Visibility = Visibility.Hidden;
                if (txt_Search.Text != "*")
                    dt = P.contact(UserName, txt_Search.Text);
                else
                    dt = P.contact(UserName, "");

                for (int i = 0; i < dt.Rows.Count; i++)
                    LV_Search.Items.Add(dt.Rows[i]["name"].ToString());
            }
            else
            {
                Clear();
                Search.Visibility = Visibility.Visible;
            }
        }

        #endregion

        #region Selection Changed

        private void LV_Search_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < LV_Search.Items.Count; i++)
            {
                if (LV_Search.Items[i] == LV_Search.SelectedItem)
                {
                    Clear();
                    txt_Name.Text = dt.Rows[i]["name"].ToString();
                    txt_Jop.Text = dt.Rows[i]["jop"].ToString();
                    txt_Phone.Text = dt.Rows[i]["phone"].ToString();
                    txt_Age.Text = dt.Rows[i]["Age"].ToString();
                    txt_Gender.Text = dt.Rows[i]["gender"].ToString();
                    txt_Address.Text = dt.Rows[i]["address"].ToString();
                    if (dt.Rows[i]["photo"] != DBNull.Value)
                        Photo.Source = Person.ByteToImage((byte[])dt.Rows[i]["photo"]);
                    break;
                }
            }
        }

        #endregion

        #region Clear Method

        private void Clear()
        {
            txt_Name.Clear();
            txt_Jop.Clear();
            txt_Phone.Clear();
            txt_Age.Clear();
            txt_Gender.Clear();
            txt_Address.Clear();
            Photo.Source = null;
        }

        #endregion

        #region Search Input

        private void txt_Search_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            I.NumbersCharcters(sender, e);
            if (e.Key == Key.Multiply)
                e.Handled = false;
        }

        #endregion

        #region Close Button

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
