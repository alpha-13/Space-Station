using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Data;

namespace Station.GUI
{
    public partial class Decisions : Window
    {
        string UserName, AName, Jop;

        Classes.Decisions D;
        Classes.Input I;
        DataTable dt;

        public Decisions(string UserName, string Name, string Jop)
        {
            InitializeComponent();

            this.UserName = UserName;
            this.AName = Name;
            this.Jop = Jop;

            btn_Decision.IsEnabled = false;
            I = new Classes.Input(txt_Message);
            D = new Classes.Decisions();
            Date_Post.SelectedDate = DateTime.Now.Date;
        }

        #region Buttons

        #region Decision
        private void btn_Decision_Click(object sender, RoutedEventArgs e)
        {
            txt_Message.Opacity = -0.01;
            if (txt_Title.Text.Length > 0)
                if (txt_Cost.Text.Length > 0 || (txt_Cost.Text.Length > 0 && Convert.ToInt64(txt_Cost.Text) == 0))
                {
                    string txt = new TextRange(rtb_Description.Document.ContentStart, rtb_Description.Document.ContentEnd).Text;
                    if (txt.Length >= 10)
                    {
                        D.SendDecision((Jop == "Engineer" ? true : false), UserName, txt_Title.Text, txt, AName, txt_Cost.Text);
                        MessageBox.Show("Decision send successfully !", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        btn_New_Click(null, null);
                    }
                    else
                        I.Message("Description must contain 10 chars or more !");
                }
                else
                    I.Message("Cost must contain a valid value !");
            else
                I.Message("Please set title for this description !");
        }
        #endregion

        #region New
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            rtb_Description.Document.Blocks.Clear();
            rtb_Decision.Document.Blocks.Clear();
            txt_Cost.Clear();
            txt_Title.Clear();
            Date_Post.SelectedDate = null;
            CB_Seen.IsChecked = false;
            CB_State.IsChecked = false;
            txt_Title.IsEnabled = true;
            txt_Cost.IsEnabled = true;
            rtb_Description.IsEnabled = true;
            btn_Decision.IsEnabled = true;
            Date_Post.SelectedDate = DateTime.Now.Date;
        }
        #endregion

        #region Back
        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion

        #region Search 
        private void txt_Search_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txt_Search.Text.Length > 0)
            {

                if (txt_Search.Text != "*")
                    dt = D.SearchDecisions(UserName, txt_Search.Text);
                else
                    dt = D.SearchDecisions(UserName, "");
                if (dt.Rows.Count > 0)
                {
                    LV_Decitions.Items.Clear();
                    LV_Decitions.Visibility = Visibility.Visible;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (LV_Decitions.Height <= 75)
                            LV_Decitions.Height += 25;
                        LV_Decitions.Items.Add(dt.Rows[i]["Title"].ToString());
                    }
                }
            }
            else
                LV_Decitions.Visibility = Visibility.Hidden;
        }
        #endregion

        #region Return Search Result
        private void LV_Decitions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < LV_Decitions.Items.Count; i++)
            {
                if (LV_Decitions.Items[i] == LV_Decitions.SelectedItem)
                {
                    rtb_Description.Document.Blocks.Clear();
                    rtb_Decision.Document.Blocks.Clear();

                    rtb_Description.Document.Blocks.Add(new Paragraph(new Run(dt.Rows[i]["Description"].ToString())));
                    if (Jop == "Astronaut" && (bool)dt.Rows[i]["statue"] && (decimal)dt.Rows[i]["supporting_cost"] >= (decimal)dt.Rows[i]["Cost"])
                    {
                        rtb_Decision.Document.Blocks.Add(new Paragraph(new Run(dt.Rows[i]["Decision"].ToString() + "\n\n\nSupporting Cost: " + dt.Rows[i]["supporting_cost"].ToString() + "\n\nMission Code: " + dt.Rows[i]["ID"].ToString() + "\n\nReplay Date: " + dt.Rows[i]["date_of_replay"].ToString())));
                        if (!(bool)dt.Rows[i]["CodeSaved"])
                            D.AddSuttleCode(UserName, (int)dt.Rows[i]["ID"]);
                    }
                    else if ((Jop == "Engineer") && (bool)dt.Rows[i]["statue"] && (decimal)dt.Rows[i]["supporting_cost"] >= (decimal)dt.Rows[i]["Cost"])
                        rtb_Decision.Document.Blocks.Add(new Paragraph(new Run(dt.Rows[i]["Decision"].ToString() + "\nSupporting Cost: " + dt.Rows[i]["supporting_cost"].ToString() + "\n\nReplay Date: " + dt.Rows[i]["date_of_replay"].ToString())));
                    else
                        rtb_Decision.Document.Blocks.Add(new Paragraph(new Run(dt.Rows[i]["Decision"].ToString())));

                    Date_Post.SelectedDate = (DateTime)dt.Rows[i]["date_of_post"];
                    CB_State.IsChecked = (bool)dt.Rows[i]["statue"];
                    CB_Seen.IsChecked = (bool)dt.Rows[i]["Seen"];
                    txt_Cost.Text = dt.Rows[i]["Cost"].ToString();
                    txt_Title.Text = LV_Decitions.SelectedItem.ToString();
                    LV_Decitions.Visibility = Visibility.Hidden;
                    txt_Title.IsEnabled = false;
                    txt_Cost.IsEnabled = false;
                    rtb_Description.IsEnabled = false;
                    btn_Decision.IsEnabled = false;
                    txt_Search.Text = null;
                    break;
                }
            }
        }
        #endregion

        #region Input

        #region Accept Only Characters(a => z - A => Z - *)
        private void txt_Search_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            I.Chracters(sender, e);
            if (e.Key == Key.Multiply)
                e.Handled = false;
        }
        #endregion

        #region Accept Only Characters (a => z - A => Z)
        private void txt_Title_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            I.Chracters(sender, e);
        }
        #endregion

        #region Accept Only Numbers (0 => 9)
        private void txt_Cost_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            I.Numbers(sender, e);
        }
        #endregion

        #endregion
    }
}
