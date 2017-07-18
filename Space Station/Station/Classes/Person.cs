using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Station.Classes
{
    internal class Person
    {

        Data.DataAccessLayer Data = new Data.DataAccessLayer();

        #region Register

        public void register(byte[] image, params string[] uName_Name_Pass_Jop_Add_Pho)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 30);
            param[2] = new SqlParameter("@password", SqlDbType.NVarChar, 100);
            param[3] = new SqlParameter("@jop", SqlDbType.NVarChar, 25);
            param[4] = new SqlParameter("@address", SqlDbType.NVarChar, 250);
            param[5] = new SqlParameter("@phone", SqlDbType.NChar, 11);
            param[6] = new SqlParameter("@image", SqlDbType.Image);

            for (int i = 0; i < 6; i++)
                param[i].Value = uName_Name_Pass_Jop_Add_Pho[i];

            param[6].Value = image;

            Data.ExecuteCommand("Person_Info", param);
        }

        #endregion

        #region Login

        public DataRow login(string name, string password)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@password", SqlDbType.NVarChar, 100);
            param[0].Value = name;
            param[1].Value = password;

            DataTable login = Data.selectData("P_Login", param);
            return (login.Rows.Count == 1 ? login.Rows[0] : null);
        }

        #endregion

        #region set access time and statue

        public void access(bool state, bool access, params string[] uName_Name_Jop)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@name", SqlDbType.NVarChar, 30);
            param[2] = new SqlParameter("@jop", SqlDbType.NVarChar, 25);
            param[3] = new SqlParameter("@date_of_access", SqlDbType.DateTime);
            param[4] = new SqlParameter("@state", SqlDbType.Bit);
            param[5] = new SqlParameter("@access", SqlDbType.Bit);

            for (int i = 0; i < 3; i++)
                param[i].Value = uName_Name_Jop[i];
            param[3].Value = DateTime.Now;
            param[4].Value = state;
            param[5].Value = access;

            Data.ExecuteCommand("access_pepole", param);
        }

        #endregion

        #region Image

        #region Image To Byte

        public static byte[] ImageToByte(BitmapSource image)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }

        #endregion

        #region Byte To Image

        public static ImageSource ByteToImage(byte[] ImageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(ImageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        #endregion

        #endregion

        #region Send Report

        public void Reporting(int ID, params string[] uName_Author_Title_Report)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@author", SqlDbType.NVarChar, 30);
            param[2] = new SqlParameter("@Title", SqlDbType.NVarChar, 50);
            param[3] = new SqlParameter("@report", SqlDbType.NVarChar);
            param[4] = new SqlParameter("@ID", SqlDbType.Int);

            for (int i = 0; i < 4; i++)
            {
                param[i].Value = uName_Author_Title_Report[i];
            }
            param[4].Value = ID;

            Data.ExecuteCommand("set_report", param);
        }

        #endregion

        #region Get Information

        public DataTable getInformation(string userName)
        {
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@user_name", SqlDbType.NVarChar, 50);
            param.Value = userName;

            return Data.selectData("get_information", param);
        }

        #endregion

        #region Search

        public DataTable Search(string Name)
        {
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            param.Value = Name;

            return Data.selectData("search", param);
        }

        #endregion

        #region Report Search

        public DataTable SearchReport(string UserName, string Title)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@Title", SqlDbType.NVarChar, 50);
            param[0].Value = UserName;
            param[1].Value = Title;

            return Data.selectData("select_Report", param);
        }

        #endregion

        #region Contact

        public DataTable contact(string UserName, string Search)
        {
            SqlParameter[] parm = new SqlParameter[2];

            parm[0] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            parm[1] = new SqlParameter("@Search", SqlDbType.NVarChar, 50);

            parm[0].Value = UserName;
            parm[1].Value = Search;

            return Data.selectData("Contact", parm);
        }

        #endregion

        #region Update Information

        public void update(string UserName, byte[] Photo, params string[] Name_Pass_Phone_Add_Age_Gender)
        {
            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@userName", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@name", SqlDbType.NVarChar, 30);
            param[2] = new SqlParameter("@password", SqlDbType.NVarChar, 100);
            param[3] = new SqlParameter("@phone", SqlDbType.NChar, 11);
            param[4] = new SqlParameter("@address", SqlDbType.NVarChar, 250);
            param[5] = new SqlParameter("@age", SqlDbType.Int);
            param[6] = new SqlParameter("@gender", SqlDbType.NVarChar, 10);
            param[7] = new SqlParameter("@photo", SqlDbType.Image);

            param[0].Value = UserName;
            param[1].Value = Name_Pass_Phone_Add_Age_Gender[0];
            param[2].Value = Name_Pass_Phone_Add_Age_Gender[1];
            param[3].Value = Name_Pass_Phone_Add_Age_Gender[2];
            param[4].Value = Name_Pass_Phone_Add_Age_Gender[3];
            param[5].Value = Name_Pass_Phone_Add_Age_Gender[4];
            param[6].Value = Name_Pass_Phone_Add_Age_Gender[5];
            param[7].Value = Photo;

            Data.ExecuteCommand("UpdateInformation", param);
        }

        #endregion

        #region Log Out

        public void logout(string UserName)
        {
            SqlParameter param = new SqlParameter("User_Name", SqlDbType.NVarChar, 50);
            param.Value = UserName;

            Data.ExecuteCommand("Update_Logout", param);
        }

        #endregion
    }
}
