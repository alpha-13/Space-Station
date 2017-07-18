using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Data;
using Station.Classes;

namespace Station.GUI.Actors
{
    public partial class Employee : Window
    {
        int ID;
        string UserName;

        Options Op;
        Input IM;
        DataTable dt = new DataTable();
        DataRow Info;

        Classes.Employee E = new Classes.Employee();

        public Employee(DataRow Info)
        {
            InitializeComponent();

            this.Info = Info;
            txt_Name.Text = Info["name"].ToString();
            UserName = Info["user_name"].ToString();
            if (Info["photo"] != DBNull.Value)
                Photo.ImageSource = Classes.Person.ByteToImage((byte[])Info["photo"]);

            GetInfo();

            Op = new Options(Options);
            IM = new Input(txt_Message);
        }

        #region Confirm Task Button

        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (!(CB_Finished.IsChecked == true && CB_Accept.IsChecked == false))
            {
                Classes.Employee E = new Classes.Employee();
                E.confirmTask(ID, (CB_Accept.IsChecked == true ? true : false), DateOfFinish.SelectedDate.Value.Date, new TextRange(Report.Document.ContentStart, Report.Document.ContentEnd).Text, (CB_Finished.IsChecked == true ? true : false));
                clear();
                GetInfo();
                Report.IsEnabled = false;
                Send.IsEnabled = false;
            }
            else
                IM.Message("Please Check Accepted If You Finish This Report");
        }

        #endregion

        #region Methos

        #region Get Tasks And Information

        private void GetInfo()
        {
            DateOfFinish.SelectedDate = DateTime.Now;

            // Check Tasks which isn't seen before! 

            dt = E.checkTasks(Info["name"].ToString(), false);

            for (int i = 0; i < dt.Rows.Count; i++)
                LVTasks.Items.Add(dt.Rows[i]["title"].ToString());

            // Check Seen Tasks

            DataTable dt2 = E.checkTasks(Info["name"].ToString(), true);


            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                LVTasks.Items.Add(dt2.Rows[i]["title"].ToString());
                dt.ImportRow(dt2.Rows[i]);
            }

        }

        #endregion

        #region Clear All Controls

        private void clear()
        {
            LVTasks.Items.Clear();
            txt_Author.Text = "";
            txt_Title.Text = "";
            PostDate.Text = "";
            FinishDate.Text = "";
            CB_Finished.IsChecked = false;
            CB_Accept.IsChecked = true;
            rtb_Task.Document.Blocks.Clear();
            Report.Document.Blocks.Clear();
        }

        #endregion

        #endregion

        #region LV Task Selected

        private void LVTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < LVTasks.Items.Count; i++)
            {
                if (LVTasks.Items[i] == LVTasks.SelectedItem)
                {
                    ID = (int)dt.Rows[i]["ID"];
                    if (!(bool)dt.Rows[i]["seen"])
                        E.TaskSeen(ID);

                    rtb_Task.Document.Blocks.Clear();
                    Report.Document.Blocks.Clear();
                    rtb_Task.Document.Blocks.Add(new Paragraph(new Run(dt.Rows[i]["task"].ToString())));
                    Report.Document.Blocks.Add(new Paragraph(new Run(dt.Rows[i]["report"].ToString())));
                    txt_Author.Text = dt.Rows[i]["author"].ToString();
                    txt_Title.Text = dt.Rows[i]["title"].ToString();
                    PostDate.Text = dt.Rows[i]["date_of_post"].ToString();
                    FinishDate.Text = dt.Rows[i]["date_of_finish"].ToString();

                    Report.IsEnabled = true;
                    Send.IsEnabled = true;
                }
            }
        }
       
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
            E.logout(UserName);
            M.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            E.logout(UserName);
            Op.Close();
        }

        #endregion
    }
}
