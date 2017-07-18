using System;
using System.Data;
using System.Data.SqlClient;

namespace Station.Classes
{
    internal sealed class Engineer : Decisions
    {
        Data.DataAccessLayer Data = new Data.DataAccessLayer();

        #region Math Operation

        public void mathOperation()
        {
            System.Diagnostics.Process.Start("calc");
        }

        #endregion

        #region Send Task

        public void setTask(params string[] userName_author_title_target_task)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@user_name", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@author", SqlDbType.NVarChar, 30);
            param[2] = new SqlParameter("@title", SqlDbType.NVarChar, 100);
            param[3] = new SqlParameter("@target", SqlDbType.NVarChar, 30);
            param[4] = new SqlParameter("@task", SqlDbType.NVarChar);
            param[5] = new SqlParameter("@date_of_post", SqlDbType.DateTime);

            for (int i = 0; i < 5; i++)
            {
                param[i].Value = userName_author_title_target_task[i];
            }
            param[5].Value = DateTime.Now;

            Data.ExecuteCommand("Add_Task", param);

        }

        #endregion

        #region Search Employee

        public DataTable SearchEmployee(string Name)
        {
            SqlParameter param = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            param.Value = Name;
            return Data.selectData("Search_Employee", param);
        }

        #endregion

        #region Select Task

        public DataTable SelectTask(string Target_UserName, string Auther_UserName)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@target_user_name", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@auther_user_name", SqlDbType.NVarChar, 50);

            param[0].Value = Target_UserName;
            param[1].Value = Auther_UserName;

            return Data.selectData("select_task", param);
        }

        #endregion

        #region Delete Task

        public void DeleteTask(int ID)
        {
            SqlParameter param = new SqlParameter("@ID", SqlDbType.Int);
            param.Value = ID;

            Data.ExecuteCommand("DeleteTask", param);
        }

        #endregion

        #region Comments
        //#region Send Equipment
        //public void sendEqu(params string[] uName_Desc_Auth_Cost)
        //{
        //    sendDecision(true, uName_Desc_Auth_Cost);
        //}
        //#endregion

        //#region Search Decisions
        //public DataTable SearchDecisions(string UserName, string Title)
        //{
        //    return SearchDecisions(UserName, Title);
        //}
        //#endregion
        #endregion
    }
}
