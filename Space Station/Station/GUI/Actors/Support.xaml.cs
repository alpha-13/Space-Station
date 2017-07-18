using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Data;

namespace Station.GUI.Actors
{
    public partial class Support : Window
    {
        Classes.Support S = new Classes.Support();
        DataTable dt = new DataTable();
        DataRow Info;
        int ID;
        int? S_ID = null;
        string UserName;
        Classes.Options Op;
        Classes.Input IM;

        public Support(DataRow Info)
        {
            InitializeComponent();

            this.Info = Info;

            txt_Name.Text = Info["name"].ToString();
            UserName = Info["user_name"].ToString();
            if (Info["photo"] != DBNull.Value)
                Photo.ImageSource = Classes.Person.ByteToImage((byte[])Info["photo"]);

            CB_Mission_Click(null, null);

            Op = new Classes.Options(Options);
            IM = new Classes.Input(txt_Message);
        }

        #region (Deposit - Send Decision) Buttons

        #region Show Deposit Form

        private void btn_Deposit_Click(object sender, RoutedEventArgs e)
        {
            Check_Balance CB = new Check_Balance();
            CB.ShowDialog();
            txt_Cost.Text = CB.text;
            S_ID = CB.S_ID;
            CB.Close();
        }

        #endregion

        #region Send Decision

        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (S_ID != null)
                {
                    S.Deposit(S_ID, Convert.ToInt64(txt_Cost.Text));
                    CB_Mission_Click(null, null);
                }
                else
                    MessageBox.Show("Enta ma7atetsh flosssss yasta ma to7ot gondy 3ashan 5ater masssssssssr", "Saba7 3la elbarnameg", MessageBoxButton.OK, MessageBoxImage.Information);

                S.sendDecisions((int)dt.Rows[ID]["ID"], new TextRange(rtb_Decision.Document.ContentStart, rtb_Decision.Document.ContentEnd).Text, (CB_State.IsChecked == true || Convert.ToInt32(txt_Cost.Text) > 0 ? true : false), Convert.ToDecimal(txt_Cost.Text));
            }
            catch
            {
                IM.Message("Sorry There is a problem in the program :(");
                clear();
            }
        }

        #endregion

        #endregion

        #region If LV Missions selected changed
        private void LV_Equ_Missions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < LV_Equ_Missions.Items.Count; i++)
            {
                if (LV_Equ_Missions.Items[i] == LV_Equ_Missions.SelectedItem)
                {
                    btn_Send.IsEnabled = true;
                    txt_Title.Text = dt.Rows[i]["Title"].ToString();
                    Posting_Date.Text = dt.Rows[i]["date_of_post"].ToString();
                    rtb_Description.Document.Blocks.Clear();
                    rtb_Description.Document.Blocks.Add(new Paragraph(new Run(dt.Rows[i]["description"].ToString())));
                    rtb_Description.Document.Blocks.Add(new Paragraph(new Run("Cost: " + dt.Rows[i]["cost"].ToString())));
                    ID = i;
                    break;
                }
            }
        }
        #endregion

        #region Check Missions or Equipment
        private void CB_Mission_Click(object sender, RoutedEventArgs e)
        {
            LV_Equ_Missions.Items.Clear();
            clear();
            btn_Send.IsEnabled = false;
            if (!(CB_Equ.IsChecked == false && CB_Mission.IsChecked == false))
            {
                bool? Equ = null;
                if (CB_Equ.IsChecked == true && CB_Mission.IsChecked == false)
                    Equ = true;
                else if (CB_Mission.IsChecked == true && CB_Equ.IsChecked == false)
                    Equ = false;

                dt = S.checkMissions_Equ(Equ);

                for (int i = 0; i < dt.Rows.Count; i++)
                    LV_Equ_Missions.Items.Add(dt.Rows[i]["Title"]);
            }
        }
        #endregion

        #region Clear
        void clear()
        {
            rtb_Decision.Document.Blocks.Clear();
            rtb_Description.Document.Blocks.Clear();
            txt_Title.Clear();
            Posting_Date.SelectedDate = null;
            txt_Cost.Text = "0";
            CB_State.IsChecked = false;
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
            S.logout(UserName);
            M.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            S.logout(UserName);
            Op.Close();
        }

        #endregion
    }
}
