using System.Data;
using System.Data.SqlClient;
using Shuttle.Data;

namespace Shuttle.Classes
{
    public sealed class Plant
    {
        DataAccessLayer Data = new DataAccessLayer();

        #region Send Information
        public void sendInformation(byte[] image, string Description, params string[] informaion)
        {
            SqlParameter[] param = new SqlParameter[14];
            param[0] = new SqlParameter("@ShuttleName", SqlDbType.NVarChar, 100);
            param[1] = new SqlParameter("@Planetary_system", SqlDbType.NVarChar, 50);
            param[2] = new SqlParameter("@Astronaut", SqlDbType.NVarChar, 50);
            param[3] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            param[4] = new SqlParameter("@Water", SqlDbType.NVarChar, 50);
            param[5] = new SqlParameter("@Temperature", SqlDbType.NVarChar, 50);
            param[6] = new SqlParameter("@Live", SqlDbType.NVarChar, 50);
            param[7] = new SqlParameter("@Year", SqlDbType.NVarChar, 50);
            param[8] = new SqlParameter("@Moons", SqlDbType.NVarChar, 50);
            param[9] = new SqlParameter("@Oxygen", SqlDbType.NVarChar, 50);
            param[10] = new SqlParameter("@Carbon_Dioxide", SqlDbType.NVarChar, 50);
            param[11] = new SqlParameter("@Nitrogen", SqlDbType.NVarChar, 50);
            param[12] = new SqlParameter("@Description", SqlDbType.NVarChar);
            param[13] = new SqlParameter("@image", SqlDbType.Image);

            for (int i = 0; i < 12; i++)
            {
                param[i].Value = informaion[i];
            }

            param[12].Value = Description;
            param[13].Value = image;
            Data.ExecuteCommand("Insert_Plants", param);
        }
        #endregion

        #region Select Data

        public DataTable SelectInformation(bool Search, string Name, string Astronaut, string ShuttleName)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            param[1] = new SqlParameter("@Astronaut", SqlDbType.NVarChar, 50);
            param[2] = new SqlParameter("@ShuttleName", SqlDbType.NVarChar, 100);
            param[3] = new SqlParameter("@Search", SqlDbType.Bit);

            param[0].Value = Name;
            param[1].Value = Astronaut;
            param[2].Value = ShuttleName;
            param[3].Value = Search;

            return Data.selectData("Select_Plant", param);
        }

        #endregion
    }
}
