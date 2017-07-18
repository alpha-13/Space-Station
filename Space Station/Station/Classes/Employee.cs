using System;
using System.Data;
using System.Data.SqlClient;

namespace Station.Classes
{
    internal sealed class Employee : Person
    {
        Data.DataAccessLayer Data = new Data.DataAccessLayer();

        #region Check Tasks

        public DataTable checkTasks(string target, bool state_seen)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@target", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@state", SqlDbType.Bit);
            param[2] = new SqlParameter("@seen", SqlDbType.Bit);

            param[0].Value = target;
            param[1].Value = state_seen;
            param[2].Value = state_seen;

            return Data.selectData("select_tasks", param);
        }

        #endregion

        #region Confirm Tasks

        public void confirmTask(int ID, bool State, DateTime? Finish_Date, string Report, bool Finished)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[1] = new SqlParameter("@state", SqlDbType.Bit);
            param[2] = new SqlParameter("@date_of_finish", SqlDbType.DateTime);
            param[3] = new SqlParameter("@report", SqlDbType.NVarChar);
            param[4] = new SqlParameter("@finish", SqlDbType.Bit);

            param[0].Value = ID;
            param[1].Value = State;
            param[2].Value = Finish_Date;
            param[3].Value = Report;
            param[4].Value = Finished;

            Data.ExecuteCommand("confirm_Task", param);
        }

        #endregion

        #region Task Seen

        public void TaskSeen(int ID)
        {
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
            param.Value = ID;
            Data.ExecuteCommand("UpdateSeen", param);
        }

        #endregion
    }
}
