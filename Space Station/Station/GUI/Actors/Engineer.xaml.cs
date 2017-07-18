using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Data;
using Station.Classes;

namespace Station.GUI.Actors
{
    public partial class Engineer : Window
    {
        int taskIndex = 0, TaskID = -1;
        string UserName;

        Options Op;

        Person P = new Person();
        Classes.Engineer E = new Classes.Engineer();

        DataRow Info;
        DataTable dt;
        DataTable tasks;
        
        public Engineer(DataRow Info)
        {
            InitializeComponent();

            this.Info = Info;

            txt_Name.Text = Info["name"].ToString();
            UserName = Info["user_name"].ToString();
            if (Info["photo"] != DBNull.Value)
                Photo.ImageSource = Classes.Person.ByteToImage((byte[])Info["photo"]);

            Op = new Options(Options);

            GetEmployees("");
        }

        #region (Calculator - Send Tasks - Decisions - Reporting - Contact - Next - Previous - Delete ) Buttons

        #region Calculator
        private void btn_Calc_Click(object sender, RoutedEventArgs e)
        {
            E.mathOperation();
        }
        #endregion

        #region Send Tasks
        private void btn_Send_Tasks_Click(object sender, RoutedEventArgs e)
        {
            Tasks T = new Tasks(UserName, Info["name"].ToString());
            T.ShowDialog();
        }
        #endregion

        #region Decisions
        private void btn_Decisions_Click(object sender, RoutedEventArgs e)
        {
            Decisions D = new Decisions(UserName, txt_Name.Text, "Engineer");
            D.ShowDialog();
        }
        #endregion

        #region Reporting
        private void btn_Reporting_Click(object sender, RoutedEventArgs e)
        {
            Reporting R = new Reporting(UserName, txt_Name.Text);
            R.ShowDialog();
        }
        #endregion

        #region Contact
        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            GUI.Contact C = new GUI.Contact(UserName);
            C.ShowDialog();
        }
        #endregion

        #region Next
        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            btn_previous.Visibility = Visibility.Visible;
            if (taskIndex < tasks.Rows.Count - 1)
            {
                ShowTask(++taskIndex);
                txt_Tasks.Text = taskIndex + 1 + " From " + tasks.Rows.Count;
            }

            if ((bool)tasks.Rows[taskIndex]["state"] == false)
                btn_DeleteTask.Visibility = Visibility.Visible;
            else
                btn_DeleteTask.Visibility = Visibility.Hidden;

            if (taskIndex == tasks.Rows.Count - 1)
                btn_next.Visibility = Visibility.Hidden;
        }
        #endregion

        #region Previous
        private void btn_previous_Click(object sender, RoutedEventArgs e)
        {
            btn_next.Visibility = Visibility.Visible;
            if (taskIndex > 0)
            {
                txt_Tasks.Text = taskIndex + " From " + tasks.Rows.Count;
                ShowTask(--taskIndex);
            }

            if ((bool)tasks.Rows[taskIndex]["state"] == false)
                btn_DeleteTask.Visibility = Visibility.Visible;
            else
                btn_DeleteTask.Visibility = Visibility.Hidden;

            if (taskIndex == 0)
                btn_previous.Visibility = Visibility.Hidden;
        }
        #endregion

        #region Delete
        private void btn_DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            E.DeleteTask(TaskID);
            LV_Employees_SelectionChanged(null, null);
        }
        #endregion

        #endregion

        #region LV Employees Selection Changed

        private void LV_Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < LV_Employees.Items.Count; i++)
            {
                if (LV_Employees.Items[i] == LV_Employees.SelectedItem)
                {
                    clear();
                    tasks = E.SelectTask(dt.Rows[i]["user_name"].ToString(), UserName);
                    if (tasks.Rows.Count > 0)
                    {
                        txt_Tasks.Text = "1 From " + tasks.Rows.Count;
                        taskIndex = 0;
                        ShowTask(taskIndex);

                        if (tasks.Rows.Count > 1)
                        {
                            btn_next.Visibility = Visibility.Visible;
                            txt_Tasks.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            btn_next.Visibility = Visibility.Hidden;
                            btn_previous.Visibility = Visibility.Hidden;
                            txt_Tasks.Visibility = Visibility.Hidden;
                        }

                        if ((bool)tasks.Rows[0]["state"] == false)
                            btn_DeleteTask.Visibility = Visibility.Visible;
                        else
                            btn_DeleteTask.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        btn_next.Visibility = Visibility.Hidden;
                        btn_previous.Visibility = Visibility.Hidden;
                        txt_Tasks.Visibility = Visibility.Hidden;
                        btn_DeleteTask.Visibility = Visibility.Hidden;
                        taskIndex = -1;
                    }
                    break;
                }
            }
        }

        #endregion

        #region Search
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search.Text.Length > 0)
            {
                Hint.Visibility = Visibility.Hidden;
                GetEmployees(Search.Text);
            }
            else
            {
                Hint.Visibility = Visibility.Visible;
                GetEmployees("");
            }
        }
        #endregion

        #region Methods

        #region Get Employees
        private void GetEmployees(string Name)
        {
            dt = E.SearchEmployee(Name);
            LV_Employees.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
                LV_Employees.Items.Add(dt.Rows[i]["name"].ToString());
        }
        #endregion

        #region Show Task
        private void ShowTask(int index)
        {
            TaskID = (int)tasks.Rows[index]["ID"];
            txt_EmployeeName.Text = tasks.Rows[index]["target"].ToString();
            txt_Title.Text = tasks.Rows[index]["title"].ToString();
            PostDate.Text = tasks.Rows[index]["date_of_post"].ToString();
            txt_seen.Text = tasks.Rows[index]["seen"].ToString();
            txt_Accepted.Text = tasks.Rows[index]["state"].ToString();
            FinishDate.Text = tasks.Rows[index]["date_of_finish"].ToString();

            rtb_task.Document.Blocks.Clear();
            rtb_report.Document.Blocks.Clear();
            rtb_report.Document.Blocks.Add(new Paragraph(new Run(tasks.Rows[index]["report"].ToString())));
            rtb_task.Document.Blocks.Add(new Paragraph(new Run(tasks.Rows[index]["task"].ToString())));
        }
        #endregion

        #region Clear
        private void clear()
        {
            txt_EmployeeName.Text = "";
            txt_Title.Text = "";
            PostDate.Text = "";
            txt_seen.Text = "";
            txt_Accepted.Text = "";
            FinishDate.Text = "";
            txt_Tasks.Text = "0 From 0";
            rtb_report.Document.Blocks.Clear();
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
            P.logout(UserName);
            M.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            P.logout(UserName);
            Op.Close();
        }
        #endregion
    }
}
