using System;
using System.Data;
using System.Data.SqlClient;

namespace Station.Classes
{
    internal sealed class Doctor : Person
    {
        Data.DataAccessLayer Data = new Data.DataAccessLayer();

        #region Add Person Health
        public void PersonHealth(string UserName, int Age, params string[] Sex_Plu_Wei_Pre_Temp_Blo_Cho)
        {
            SqlParameter[] parm = new SqlParameter[10];
            parm[0] = new SqlParameter("@user_name", SqlDbType.NVarChar, 50);
            parm[1] = new SqlParameter("@Age", SqlDbType.Int);
            parm[2] = new SqlParameter("@Gender", SqlDbType.NVarChar, 10);
            parm[3] = new SqlParameter("@Pluse", SqlDbType.NVarChar, 50);
            parm[4] = new SqlParameter("@Weight", SqlDbType.NVarChar, 20);
            parm[5] = new SqlParameter("@Pressure", SqlDbType.NVarChar, 20);
            parm[6] = new SqlParameter("@Temp", SqlDbType.NVarChar, 20);
            parm[7] = new SqlParameter("@Blood_Type", SqlDbType.NVarChar, 20);
            parm[8] = new SqlParameter("@Cholesterol", SqlDbType.NVarChar, 20);
            parm[9] = new SqlParameter("@Report", SqlDbType.NVarChar);

            parm[0].Value = UserName;
            parm[1].Value = Age;

            for (int i = 0; i < Sex_Plu_Wei_Pre_Temp_Blo_Cho.Length; i++)
            {
                parm[2 + i].Value = Sex_Plu_Wei_Pre_Temp_Blo_Cho[i];
            }

            Data.ExecuteCommand("Health", parm);
        }
        #endregion

        #region Set Daily News As Doctor

        public void setAdvice(string Advice)
        {
            SqlParameter[] parm = new SqlParameter[3];
            parm[0] = new SqlParameter("@News", SqlDbType.NVarChar, 200);
            parm[1] = new SqlParameter("@Author", SqlDbType.NVarChar, 25);
            parm[2] = new SqlParameter("@Time", SqlDbType.DateTime);

            parm[0].Value = Advice;
            parm[1].Value = "Doctor";
            parm[2].Value = DateTime.Now.Date;

            Data.ExecuteCommand("Add_News", parm);
        }

        #endregion

        #region Check Health
        public DataTable checkHealth(string UserName)
        {
            SqlParameter param = new SqlParameter("@user_Name", SqlDbType.NVarChar, 50);
            param.Value = UserName;
            return Data.selectData("Check_Health", param);
        }
        #endregion

        #region Search 
        public DataTable HealthSearch(string Name)
        {
            SqlParameter param = new SqlParameter();
            param = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            param.Value = Name;

            return Data.selectData("SearchForDoctor", param);
        }
        #endregion
    }
}
