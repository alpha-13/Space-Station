using System.Data;
using System.Data.SqlClient;
using Shuttle.Data;

namespace Shuttle.Classes
{
    public sealed class Galaxy
    {
        DataAccessLayer Data = new DataAccessLayer();

        #region Send Information

        public void sendInformation(byte[] image, string Description, params string[] informaion)
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@ShuttleName", SqlDbType.NVarChar, 100);
            param[1] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            param[2] = new SqlParameter("@Astronaut", SqlDbType.NVarChar, 50);
            param[3] = new SqlParameter("@Age", SqlDbType.NVarChar, 50);
            param[4] = new SqlParameter("@Type", SqlDbType.NVarChar, 50);
            param[5] = new SqlParameter("@Diameter", SqlDbType.NVarChar, 50);
            param[6] = new SqlParameter("@Stars", SqlDbType.NVarChar, 50);
            param[7] = new SqlParameter("@Arms", SqlDbType.NVarChar, 50);
            param[8] = new SqlParameter("@Mass", SqlDbType.NVarChar, 50);
            param[9] = new SqlParameter("@Expansion", SqlDbType.NVarChar, 50);
            param[10] = new SqlParameter("@Density", SqlDbType.NVarChar, 50);
            param[11] = new SqlParameter("@Description", SqlDbType.NVarChar);
            param[12] = new SqlParameter("@image", SqlDbType.Image);

            for (int i = 0; i < 11; i++)
                param[i].Value = informaion[i];

            param[11].Value = Description;
            param[12].Value = image;

            Data.ExecuteCommand("Set_Galaxy_Data", param);
        }

        #endregion

        #region Select Data
        public DataTable SelectInformation(bool Search, string Name, string Astronaut, string ShuttleName)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
            param[1] = new SqlParameter("@Astronaut", SqlDbType.NVarChar, 50);
            param[2] = new SqlParameter("@ShuttleName", SqlDbType.NVarChar, 100);
            param[3] = new SqlParameter("@Search", SqlDbType.Bit);

            param[0].Value = Name;
            param[1].Value = Astronaut;
            param[2].Value = ShuttleName;
            param[3].Value = Search;

            return Data.selectData("Select_Information", param);
        }
        #endregion
    }
}
