using System;
using System.Data;
using System.Data.SqlClient;

namespace Station.Classes
{
    internal sealed class Astronaut
    {
        Data.DataAccessLayer Data = new Data.DataAccessLayer();
        Data.DataAccessLayer ShuttleData = new Data.DataAccessLayer("Space_Shuttle");

        #region Add Shuttle

        public void addShuttleMission(int Stages, double Fuel, int MissionCode, DateTime Time, params string[] Name_Astro_UName_Pass_Desc_Notes)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            param[1] = new SqlParameter("@Astronaut", SqlDbType.NVarChar, 50);
            param[2] = new SqlParameter("@User_Name", SqlDbType.NVarChar, 50);
            param[3] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            param[4] = new SqlParameter("@Stages", SqlDbType.Int);
            param[5] = new SqlParameter("@Distance", SqlDbType.NVarChar);
            param[6] = new SqlParameter("@Fuel", SqlDbType.Float);
            param[7] = new SqlParameter("@Launch_Time", SqlDbType.DateTime);
            param[8] = new SqlParameter("@Notes", SqlDbType.NVarChar);
            param[9] = new SqlParameter("@Code", SqlDbType.Int);


            param[0].Value = Name_Astro_UName_Pass_Desc_Notes[0];
            param[1].Value = Name_Astro_UName_Pass_Desc_Notes[1];
            param[2].Value = Name_Astro_UName_Pass_Desc_Notes[2];
            param[3].Value = Name_Astro_UName_Pass_Desc_Notes[3];
            param[4].Value = Stages;
            param[5].Value = Name_Astro_UName_Pass_Desc_Notes[4];
            param[6].Value = Fuel;
            param[7].Value = Time;
            param[8].Value = Name_Astro_UName_Pass_Desc_Notes[5];
            param[9].Value = MissionCode;

            Data.ExecuteCommand("add_shuttle_Mission", param);
        }

        #endregion

        #region Login New Shuttle

        public DataTable login_New_Shuttle(string Astronaut, string UserName, string password)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Astronaut", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@user_Name", SqlDbType.NVarChar, 50);
            param[2] = new SqlParameter("@password", SqlDbType.NVarChar, 50);

            param[0].Value = Astronaut;
            param[1].Value = UserName;
            param[2].Value = password;

            return Data.selectData("Login_Shuttle", param);
        }

        #endregion

        #region Login Shuttle

        public DataTable Login_Shuttle(string Name, string Password, string Astronaut)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@Shuttle_Name", SqlDbType.NVarChar, 100);
            param[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            param[2] = new SqlParameter("@Astronaut", SqlDbType.NVarChar, 50);

            param[0].Value = Name;
            param[1].Value = Password;
            param[2].Value = Astronaut;

            return ShuttleData.selectData("LoginShuttle", param);
        }

        #endregion

        #region Check Shuttle Code

        public bool CheckShuttleCode(string Astronaut, string Code)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Astronaut", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@Code", SqlDbType.Int);

            param[0].Value = Astronaut;
            param[1].Value = Code;
            return Data.selectData("CheckShuttleCode", param).Rows.Count == 1 ? true : false;
        }

        #endregion

        #region Check Shuttle Name

        public DataTable CheckShuttleName(string Astronaut, string Name)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@astronaut", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@name", SqlDbType.NVarChar, 100);

            param[0].Value = Astronaut;
            param[1].Value = Name;

            return Data.selectData("Check_Shuttle_Name", param);
        }

        #endregion

        #region News

        public void News(string News)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@News", SqlDbType.NVarChar, 200);
            param[1] = new SqlParameter("@Author", SqlDbType.NVarChar, 25);
            param[2] = new SqlParameter("@Time", SqlDbType.DateTime);

            param[0].Value = News;
            param[1].Value = "Astronaut";
            param[2].Value = DateTime.Now;

            Data.ExecuteCommand("Add_News", param);
        }

        #endregion

        #region Mission

        #region Add Mission

        public void AddMission(string ShuttleName, string MissionName, string Astronaut, DateTime Start, DateTime End, string Desc)
        {
            Data = new Data.DataAccessLayer("Space_Shuttle");
            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@ShuttleName", SqlDbType.NVarChar, 100);
            param[1] = new SqlParameter("@Mission", SqlDbType.NVarChar, 100);
            param[2] = new SqlParameter("@Astronaut", SqlDbType.NVarChar, 50);
            param[3] = new SqlParameter("@StartTime", SqlDbType.DateTime);
            param[4] = new SqlParameter("@EndTime", SqlDbType.DateTime);
            param[5] = new SqlParameter("@Desc", SqlDbType.NVarChar);

            param[0].Value = ShuttleName;
            param[1].Value = MissionName;
            param[2].Value = Astronaut;
            param[3].Value = Start;
            param[4].Value = End;
            param[5].Value = Desc;

            Data.ExecuteCommand("AddMission", param);
        }

        #endregion

        #region Select Missions

        public DataTable SelectMissions(bool IsSearch, string ShuttleName, string Name)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("@IsSearch", SqlDbType.Bit);
            param[1] = new SqlParameter("@ShuttleName", SqlDbType.NVarChar, 100);
            param[2] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);

            param[0].Value = IsSearch;
            param[1].Value = ShuttleName;
            param[2].Value = Name;

            return ShuttleData.selectData("SelectMissions", param);
        }

        #endregion

        #endregion
    }
}
