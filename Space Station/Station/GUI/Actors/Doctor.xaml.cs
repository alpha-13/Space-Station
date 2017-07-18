using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Data;
using Station.Classes;

namespace Station.GUI.Actors
{
    public partial class Doctor : Window
    {
        int Index;
        string UserName;

        Options Op;
        Input I, IM;

        Classes.Doctor D = new Classes.Doctor();

        DataRow Info;
        DataTable dt;

        public Doctor(DataRow Info)
        {
            InitializeComponent();

            this.Info = Info;

            UserName = Info["user_name"].ToString();
            txt_Name.Text = Info["name"].ToString();

            if (Info["photo"] != DBNull.Value)
                Photo.ImageSource = Person.ByteToImage((byte[])Info["photo"]);

            SearchPepole("");

            Op = new Options(Options);
            I = new Input();
            IM = new Input(txt_Message);
        }

        #region Buttons

        #region Advice

        private void Advice_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Advice.Text.Length >= 10)
                D.setAdvice(txt_Advice.Text);
            else
                IM.Message("Advice must be 10 characters or more !");
        }

        #endregion

        #region Show

        private void btn_Show_Click(object sender, RoutedEventArgs e)
        {
            DataTable Health = D.checkHealth(dt.Rows[Index]["user_name"].ToString());

            txt_Age.Text = Health.Rows[0]["Age"].ToString();
            cmb_Gender.Text = Health.Rows[0]["Gender"].ToString();
            txt_Pluse.Text = Health.Rows[0]["Pluse"].ToString();
            txt_Weight.Text = Health.Rows[0]["weight"].ToString();
            txt_Pressure.Text = Health.Rows[0]["Pressure"].ToString();
            txt_Temp.Text = Health.Rows[0]["Temperature"].ToString();
            txt_Blood.Text = Health.Rows[0]["Blood_type"].ToString();
            txt_Chole.Text = Health.Rows[0]["Cholesterol"].ToString();

            rtb_Report.Document.Blocks.Clear();
            rtb_Report.Document.Blocks.Add(new Paragraph(new Run(Health.Rows[0]["Report"].ToString())));
            btn_Show.IsEnabled = false;
            btn_New.IsEnabled = false;
        }

        #endregion

        #region New

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            Information.IsEnabled = true;
        }

        #endregion

        #region Save

        private void btn_SaveInfo_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Age.Text.Length > 0)
            {
                D.PersonHealth(dt.Rows[Index]["user_name"].ToString(), Convert.ToInt16(txt_Age.Text),
                    cmb_Gender.Text, txt_Pluse.Text, txt_Weight.Text,
                    txt_Pressure.Text, txt_Temp.Text, txt_Blood.Text, txt_Chole.Text,
                    new TextRange(rtb_Report.Document.ContentStart, rtb_Report.Document.ContentEnd).Text);
                IM.Message("Success !");
                Information.IsEnabled = false;
                clear();
            }
            else
                IM.Message("Please Enter Actor Age !");
        }

        #endregion

        #endregion

        #region LV Selected Changed

        private void LV_Pepole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clear();
            for (int i = 0; i < dt.Rows.Count; i++)
                if (LV_Pepole.Items[i] == LV_Pepole.SelectedItem)
                {
                    Index = i;
                    txt_PName.Text = dt.Rows[i]["Name"].ToString();
                    txt_PJop.Text = dt.Rows[i]["Jop"].ToString();
                    if (dt.Rows[i]["photo"] != DBNull.Value)
                        Photo2.ImageSource = Person.ByteToImage((byte[])dt.Rows[i]["photo"]);
                    else
                        Photo2.ImageSource = null;

                    btn_Show.IsEnabled = true;
                    btn_New.IsEnabled = true;
                    break;
                }
        }

        #endregion

        #region Seaarch Text Box

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text.Length > 0)
            {
                Hint.Visibility = Visibility.Hidden;
                SearchPepole(Search.Text);
            }
            else
            {
                Hint.Visibility = Visibility.Visible;
                SearchPepole("");
            }
        }

        #endregion

        #region Methods

        #region Search

        private void SearchPepole(string Name)
        {
            btn_Show.IsEnabled = false;
            btn_New.IsEnabled = false;
            LV_Pepole.SelectedItem = null;
            LV_Pepole.Items.Clear();
            txt_PName.Clear();
            txt_PJop.Clear();
            Photo2.ImageSource = null;

            dt = D.HealthSearch(Name);

            for (int i = 0; i < dt.Rows.Count; i++)
                LV_Pepole.Items.Add(dt.Rows[i]["Name"]);
        }

        #endregion

        #region Clear

        private void clear()
        {
            txt_Age.Clear();
            cmb_Gender.Items.Clear();
            txt_Pluse.Clear();
            txt_Weight.Clear();
            txt_Pressure.Clear();
            txt_Temp.Clear();
            txt_Blood.Clear();
            txt_Chole.Clear();
            rtb_Report.Document.Blocks.Clear();
        }

        #endregion

        #endregion

        #region (Edit Info - Logout - open/close) MouseDown Events - Age Input

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
            D.logout(UserName);
            M.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            D.logout(UserName);
            Op.Close();
        }

        private void txt_Age_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            I.Numbers(sender, e);
        }

        #endregion
    }
}
