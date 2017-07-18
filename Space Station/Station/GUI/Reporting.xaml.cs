using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Data;

namespace Station.GUI
{
    public partial class Reporting : Window
    {
        private string UserName;
        private string Author;

        public Reporting(string UserName, string Author)
        {
            InitializeComponent();
            this.UserName = UserName;
            this.Author = Author;
        }

        Classes.Person P = new Classes.Person();
        DataTable dt;
        int id = -1;

        #region Buttons

        #region Save
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Title.Text.Length > 0)
            {
                P.Reporting(id, UserName, Author, txt_Title.Text, new TextRange(rtb_Report.Document.ContentStart, rtb_Report.Document.ContentEnd).Text);
                if (id == -1)
                {
                    txt_Title.Clear();
                    rtb_Report.Document.Blocks.Clear();
                }
                Search_TextChanged(null, null);
                MessageBox.Show("Report Saved Successfuly", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                Title_Hint.Visibility = Visibility.Visible;
        }
        #endregion

        #region New - Close
        private void New_Click(object sender, RoutedEventArgs e)
        {
            txt_Title.Clear();
            rtb_Report.Document.Blocks.Clear();
            Title_Hint.Visibility = Visibility.Hidden;
            RDate.Visibility = Visibility.Hidden;
            Modify.Visibility = Visibility.Hidden;
            id = -1;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Print
        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sorry this function is not allowed because there is no more time to do that !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        #endregion

        #endregion

        #region Text Changed

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            LV_Tasks.Items.Clear();

            if (Search.Text.Length > 0)
            {
                Hint.Visibility = Visibility.Hidden;
                if (Search.Text != "*")
                    dt = P.SearchReport(UserName, Search.Text);
                else
                    dt = P.SearchReport(UserName, "");

                for (int i = 0; i < dt.Rows.Count; i++)
                    LV_Tasks.Items.Add(dt.Rows[i]["Title"].ToString());
            }
            else
                Hint.Visibility = Visibility.Visible;
        }

        private void txt_Title_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt_Title.Text.Length > 0)
                Title_Hint.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Selection Changed

        private void LV_Tasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < LV_Tasks.Items.Count; i++)
            {
                if (LV_Tasks.Items[i] == LV_Tasks.SelectedItem)
                {
                    txt_Title.Clear();
                    rtb_Report.Document.Blocks.Clear();
                    id = (int)dt.Rows[i]["ID"];
                    txt_Title.Text = dt.Rows[i]["Title"].ToString();
                    rtb_Report.Document.Blocks.Add(new Paragraph(new Run(dt.Rows[i]["Report"].ToString())));

                    if (dt.Rows[i]["last_modify"] != DBNull.Value)
                    {
                        Modify.Visibility = Visibility.Visible;
                        ModifyDate.SelectedDate = Convert.ToDateTime(dt.Rows[i]["last_modify"]).Date;
                    }

                    RDate.Visibility = Visibility.Visible;
                    ReportDate.SelectedDate = Convert.ToDateTime(dt.Rows[i]["date_of_post"]).Date;
                    break;
                }
            }
        }

        #endregion
    }
}
