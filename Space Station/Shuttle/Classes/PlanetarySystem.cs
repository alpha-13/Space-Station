using System.Data;
using System.Data.SqlClient;
using Shuttle.Data;

namespace Shuttle.Classes
{
    public sealed class PlanetarySystem
    {
        DataAccessLayer Data = new DataAccessLayer();

        #region Send Information

        public void sendInformation(byte[] image, string Description, params string[] informaion)
        {
            SqlParameter[] param = new SqlParameter[10];
            param[0] = new SqlParameter("@ShuttleName", SqlDbType.NVarChar, 100);
            param[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
            param[2] = new SqlParameter("@Galaxy", SqlDbType.NVarChar, 100);
            param[3] = new SqlParameter("@Astronaut", SqlDbType.NVarChar, 50);
            param[4] = new SqlParameter("@Plants", SqlDbType.NVarChar, 50);
            param[5] = new SqlParameter("@Asteroids", SqlDbType.NVarChar, 20);
            param[6] = new SqlParameter("@Location", SqlDbType.NVarChar, 200);
            param[7] = new SqlParameter("@Speed", SqlDbType.NVarChar, 50);
            param[8] = new SqlParameter("@Description", SqlDbType.NVarChar);
            param[9] = new SqlParameter("@image", SqlDbType.Image);

            for (int i = 0; i < 8; i++)
                param[i].Value = informaion[i];

            param[8].Value = Description;
            param[9].Value = image;

            Data.ExecuteCommand("Insert_Solanetary_System", param);
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

            return Data.selectData("Select_Planetary_Data", param);
        }

        #endregion
    }
}
