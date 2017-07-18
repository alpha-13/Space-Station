using System.Windows;
using System.Data;

namespace Station.GUI
{
    public partial class Check_Balance : Window
    {
        public string text { get; set; }
        public int? S_ID { set; get; }

        DataTable dt;

        Classes.Support S = new Classes.Support();
        Classes.Input I, IM;

        public Check_Balance()
        {
            InitializeComponent();

            I = new Classes.Input();
            IM = new Classes.Input(txt_Message);
        }

        #region (Check - Deposit - Cancel) Buttons

        #region Check

        private void btn_Check_Click(object sender, RoutedEventArgs e)
        {
            dt = S.check_balance(txt_ID.Text, txt_Pass.Password);

            if (dt.Rows.Count == 1)
            {
                txt_Balance.Text = dt.Rows[0]["balance"].ToString();
                S_ID = (int)dt.Rows[0]["Support_ID"];
            }
            else
                IM.Message("Sorry Your ID Or Password Is Not Correct !");
        }

        #endregion

        #region Deposit

        private void btn_Deposit_Click(object sender, RoutedEventArgs e)
        {
            if (S.check_balance(txt_ID.Text, txt_Pass.Password).Rows.Count == 1)
            {
                text = txt_Cost.Text;
                S_ID = (int)S.check_balance(txt_ID.Text, txt_Pass.Password).Rows[0]["Support_ID"];
                this.Hide();
            }
            else
            {
                S_ID = null;
                IM.Message("Sorry Your ID Or Password Is Not Correct !");
            }
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

        private void PreviewKeyDownNumbers(object sender, System.Windows.Input.KeyEventArgs e)
        {
            I.Numbers(sender, e);
        }

        private void txt_Pass_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            I.NumbersCharcters(sender, e);
        }

        #endregion
    }
}
