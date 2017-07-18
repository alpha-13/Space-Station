using System;
using System.Data;
using System.Data.SqlClient;

namespace Station.Classes
{
    internal sealed class Support : Person
    {
        Data.DataAccessLayer Data = new Data.DataAccessLayer();

        #region Check Balance

        public DataTable check_balance(string credit_ID, string Password)
        {
            SqlParameter[] parm = new SqlParameter[2];
            parm[0] = new SqlParameter("@credit_ID", SqlDbType.NVarChar, 50);
            parm[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);

            parm[0].Value = credit_ID;
            parm[1].Value = Password;

            return Data.selectData("check_balance", parm);
        }

        #endregion

        #region Deposit

        public void Deposit(int? ID, long Cost)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@S_ID", SqlDbType.Int);
            param[1] = new SqlParameter("@Balance", SqlDbType.Money);

            param[0].Value = ID;
            param[1].Value = Cost;

            Data.ExecuteCommand("NewBalance", param);
        }

        #endregion

        #region Check Missions - Equipments

        public DataTable checkMissions_Equ(bool? Equ_Mission)
        {
            SqlParameter param = new SqlParameter("@Equipment", SqlDbType.Bit);
            param.Value = Equ_Mission;
            if (Equ_Mission == null)
                param.Value = DBNull.Value;
            return Data.selectData("SupportData", param);
        }

        #endregion

        #region Send Decisions

        public void sendDecisions(int ID, string Decision, bool state, decimal cost)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[1] = new SqlParameter("@decision", SqlDbType.NVarChar);
            param[2] = new SqlParameter("@statue", SqlDbType.Bit);
            param[3] = new SqlParameter("@cost", SqlDbType.Money);
            param[4] = new SqlParameter("@ReplayDate", SqlDbType.DateTime);

            param[0].Value = ID;
            param[1].Value = Decision;
            param[2].Value = state;
            param[3].Value = cost;
            if (state)
                param[4].Value = DateTime.Now;
            else
                param[4].Value = DBNull.Value;

            Data.ExecuteCommand("insert_desition", param);
        }

        #endregion
    }
}
