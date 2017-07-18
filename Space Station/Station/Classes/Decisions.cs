using System;
using System.Data;
using System.Data.SqlClient;

namespace Station.Classes
{
    internal class Decisions
    {
        Data.DataAccessLayer Data = new Data.DataAccessLayer();

        #region Send Decision

        public void SendDecision(bool IsEquipment, params string[] uName_Title_Desc_Auth_Cost)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@title", SqlDbType.NVarChar, 50);
            param[2] = new SqlParameter("@description", SqlDbType.NVarChar);
            param[3] = new SqlParameter("@author", SqlDbType.NVarChar, 30);
            param[4] = new SqlParameter("@cost", SqlDbType.Money);
            param[5] = new SqlParameter("@date_of_post", SqlDbType.DateTime);
            param[6] = new SqlParameter("@Euip", SqlDbType.Bit);

            for (int i = 0; i < 5; i++)
            {
                param[i].Value = uName_Title_Desc_Auth_Cost[i];
            }
            param[5].Value = DateTime.Now;
            param[6].Value = IsEquipment;

            Data.ExecuteCommand("new_decision", param);
        }

        #endregion

        #region Search Decisions

        public DataTable SearchDecisions(string UserName, string Title)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@title", SqlDbType.NVarChar, 50);

            param[0].Value = UserName;
            param[1].Value = Title;

            return Data.selectData("select_Decisions", param);
        }

        #endregion

        #region Add Suttle Code

        public void AddSuttleCode(string UserName, int ID)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@ID", SqlDbType.Int);

            param[0].Value = UserName;
            param[1].Value = ID;
            Data.ExecuteCommand("AddSuttleCode", param);
        }

        #endregion
    }
}
