using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Station.Classes
{
    internal sealed class Admin
    {
        internal string num;
        Data.DataAccessLayer Data = new Data.DataAccessLayer();

        #region ADD

        public string add(string Jop)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", SqlDbType.NVarChar, 15);
            param[1] = new SqlParameter("@jop", SqlDbType.NVarChar, 25);
            param[0].Value = random();
            param[1].Value = Jop;

            Data.ExecuteCommand("ADD_PERSON", param);
            return param[0].Value.ToString();
        }

        #endregion

        #region Delete

        public void delete(string userName)
        {
            SqlParameter param = new SqlParameter("user_name", SqlDbType.NVarChar, 50);
            param.Value = userName;

            Data.ExecuteCommand("Delete_Person", param);
        }

        #endregion

        #region Shut down
        public void shutdown()
        {
            DialogResult res = MessageBox.Show("Do you want to shutdown the system !", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (res)
            {
                case DialogResult.Yes: System.Windows.Application.Current.Shutdown(); break;
                case DialogResult.No:; break;
            }
        }
        #endregion

        #region Restart

        public void restart()
        {
            DialogResult res = MessageBox.Show("Do you want to restart the system !", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (res)
            {
                case DialogResult.Yes: Application.Restart(); break;
                case DialogResult.No:; break;
            }
        }

        #endregion

        #region Get Actors

        public DataTable GetActors(string UserName, string Search)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@Search", SqlDbType.NVarChar, 100);

            param[0].Value = UserName;
            param[1].Value = Search;

            return Data.selectData("GetActors", param);
        }

        #endregion

        #region Random Number

        public string random()
        {

            Random r = new Random();
            for (int i = 0; i < 10; i++)
                num += r.Next(0, 9);

            SqlParameter param = new SqlParameter("@ID", SqlDbType.NVarChar, 15);
            param.Value = num;

            DataTable dt = Data.selectData("select_ID", param);

            if (dt.Rows.Count == 0)
                return num;
            else
                random();
            return null;
        }

        #endregion
    }
}
