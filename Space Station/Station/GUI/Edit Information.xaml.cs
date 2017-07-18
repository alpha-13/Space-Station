using System;
using System.Data;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Station.GUI
{
    public partial class Edit_Information : Window
    {
        Classes.Person P = new Classes.Person();
        Classes.Input I, IM;

        DataTable dt;

        public Edit_Information(string UserName)
        {
            InitializeComponent();

            dt = P.getInformation(UserName);

            txt_UserName.Text = UserName;
            txt_Name.Text = dt.Rows[0]["name"].ToString();
            txt_Password.Text = dt.Rows[0]["password"].ToString();
            txt_Phone.Text = dt.Rows[0]["phone"].ToString();
            txt_Jop.Text = dt.Rows[0]["jop"].ToString();
            txt_Address.Text = dt.Rows[0]["address"].ToString();
            txt_Age.Text = dt.Rows[0]["age"].ToString();
            txt_Gender.Text = dt.Rows[0]["gender"].ToString();
            if (dt.Rows[0]["photo"] != DBNull.Value)
                Photo.ImageSource = Classes.Person.ByteToImage((byte[])dt.Rows[0]["photo"]);

            I = new Classes.Input();
            IM = new Classes.Input(txt_Message);
        }

        #region (Save - Close) Buttons

        #region Save

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Name.Text.Length > 0)
                if (txt_Password.Text.Length > 0)
                {
                    P.update(txt_UserName.Text, Classes.Person.ImageToByte((BitmapSource)Photo.ImageSource), txt_Name.Text, txt_Password.Text, txt_Phone.Text, txt_Address.Text, txt_Age.Text, txt_Gender.Text);
                    IM.Message("Update Success");
                }
                else
                    IM.Message("Please Enter Password !");
            else
                IM.Message("Please Enter Name !");
        }

        #endregion

        #region Cancel

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        #endregion

        #region Select Image Method

        private void Ellipse_Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images| *.JPG; *.PNG";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImageSource image = new BitmapImage(new Uri(ofd.FileName, UriKind.Absolute));
                Photo.ImageSource = image;
            }
        }

        #endregion

        #region Input

        private void txt_CharsNum_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            I.NumbersCharcters(sender, e);
        }

        private void txt_Nums_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            I.Numbers(sender, e);
        }

        private void txt_Gender_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            I.Chracters(sender, e);
        }

        #endregion
    }
}
