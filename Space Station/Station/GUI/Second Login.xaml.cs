using System.Windows;
using System.Data;

namespace Station.GUI
{
    public partial class Second_Login : Window
    {
        Classes.Astronaut A = new Classes.Astronaut();
        Classes.Input I = new Classes.Input();
        Classes.Input I2;
        public Launch L;
        string Message;
        public bool Login { set; get; }
        DataRow AstronautInfo;

        public Second_Login(DataRow AstronautInfo)
        {
            InitializeComponent();

            this.AstronautInfo = AstronautInfo;

            I2 = new Classes.Input(txt_Message);
        }

        #region Buttons

        #region Login
        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            if (txt_UserName.Text.Length > 0)
                if (txt_Password.Password.Length > 0)
                {
                    DataTable dt = A.login_New_Shuttle(AstronautInfo["user_name"].ToString(), txt_UserName.Text, txt_Password.Password);
                    if (dt.Rows.Count == 1)
                    {
                        string[] Info = new string[6];

                        Info[0] = dt.Rows[0]["Name"].ToString();
                        Info[1] = dt.Rows[0]["Launch_Time"].ToString();
                        Info[2] = dt.Rows[0]["Stages"].ToString();
                        Info[3] = dt.Rows[0]["Distance"].ToString();
                        Info[4] = dt.Rows[0]["Fuel"].ToString();
                        Info[5] = dt.Rows[0]["Notes"].ToString();

                        L = new Launch(Info, AstronautInfo, txt_UserName.Text, txt_Password.Password);
                        Login = true;
                        this.Hide();
                    }
                    else
                        Message = "User Name or Password isn't correct!";
                }
                else
                    Message = "Please enter shuttle password !";
            else
                Message = "Please enter shuttle User Name !";

            I2.Message(Message);
        }

        #endregion

        #region Cancel

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        #endregion

        #region Input

        private void txt_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            I.NumbersCharcters(sender, e);
        }

        #endregion
    }
}
