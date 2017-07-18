using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Data;

namespace Station.GUI
{
    public partial class Tasks : Window
    {
        string UserName, AName, Message;

        DataTable dt;

        Classes.Engineer E = new Classes.Engineer();
        Classes.Input IM;

        public Tasks(string UserName, string Name)
        {
            InitializeComponent();

            this.UserName = UserName;
            this.AName = Name;

            IM = new Classes.Input(txt_Message);

            Search_TextChanged(null, null);
        }

        #region (Send - Close) Buttons

        #region Send

        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Title.Text.Length > 0)
                if (new TextRange(rtb_Task.Document.ContentStart, rtb_Task.Document.ContentEnd).Text.Length > 10)
                {
                    E.setTask(UserName, AName, txt_Title.Text, txt_Target.Text, new TextRange(rtb_Task.Document.ContentStart, rtb_Task.Document.ContentEnd).Text);
                    txt_Target.Clear();
                    txt_Title.Clear();
                    rtb_Task.Document.Blocks.Clear();

                    Message = "Task Sended Successfully !";
                }
                else
                    Message = "Task Description Must Be greater Than 10 Characters !";
            else
                Message = "Please Enter Task Title";

            IM.Message(Message);
        }

        #endregion

        #region Close

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        #endregion

        #region Search Text Changed

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            btn_Send.IsEnabled = false;

            if (txt_Search.Text.Length > 0)
                Hint.Visibility = Visibility.Hidden;
            else
                Hint.Visibility = Visibility.Visible;

            dt = E.SearchEmployee(txt_Search.Text);

            LV_Employees.Items.Clear();

            if (dt.Rows.Count > 0)
                for (int i = 0; i < dt.Rows.Count; i++)
                    LV_Employees.Items.Add(dt.Rows[i]["Name"].ToString());
        }

        #endregion

        #region LV Employees Selection Changed

        private void LV_Employees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < LV_Employees.Items.Count; i++)
                if (LV_Employees.Items[i] == LV_Employees.SelectedItem)
                {
                    txt_Target.Text = LV_Employees.SelectedItem.ToString();
                    btn_Send.IsEnabled = true;
                    break;
                }
        }

        #endregion
    }
}
