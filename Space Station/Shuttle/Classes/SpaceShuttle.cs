using System.Data;
using System.Data.SqlClient;

namespace Shuttle.Classes
{
    public class SpaceShuttle
    {
        Data.DataAccessLayer Data = new Shuttle.Data.DataAccessLayer();
        Data.DataAccessLayer Data2 = new Shuttle.Data.DataAccessLayer("Space_Station");

        #region Get Information

        public DataTable getInformation(string Type, string Astronaut)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Type", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@Astronaut", SqlDbType.NVarChar, 50);

            param[0].Value = Type;
            param[1].Value = Astronaut;

            return Data.selectData("Random_Info", param);
        }

        #endregion

        #region Check Shuttle UserName

        public DataTable checkSuttleUserName(string Astronaut, string UserName)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@Astronaut", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@UserName", SqlDbType.NVarChar, 100);

            param[0].Value = Astronaut;
            param[1].Value = UserName;

            return Data2.selectData("Check_Shuttle_UN", param);
        }

        #endregion

        #region New Shuttle

        public void NewShuttle(string ShuttleUN, string Password, string Name)
        {
            Deletelaunch(ShuttleUN);

            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@ShuttleName", SqlDbType.NVarChar, 100);
            param[1] = new SqlParameter("@Password", SqlDbType.NVarChar, 50);
            param[2] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);

            param[0].Value = ShuttleUN;
            param[1].Value = Password;
            param[2].Value = Name;

            Data.ExecuteCommand("NewShuttle", param);
        }

        #endregion

        #region Delete Launch

        private void Deletelaunch(string UserName)
        {
            SqlParameter param = new SqlParameter("@UserName", SqlDbType.NVarChar, 50);
            param.Value = UserName;
            Data2.ExecuteCommand("DeleteLaunch", param);
        }

        #endregion
    }
}
