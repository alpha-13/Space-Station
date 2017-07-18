using System.Data;
using System.Data.SqlClient;

namespace Station.Classes
{
    internal sealed class Security : Person
    {
        Data.DataAccessLayer Data = new Data.DataAccessLayer();

        #region check access pepole

        public DataTable checkAccess(string Name)
        {
            SqlParameter param = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param.Value = Name;

            return Data.selectData("check_access", param);
        }

        #endregion

        #region check fault access

        public DataTable faultAccess()
        {
            return Data.selectData("fault_pepole");
        }

        #endregion

        #region Last Seen

        public void LastSeen(string UserName, out string Laccess, out string Lseen)
        {
            SqlParameter param = new SqlParameter("@user_name", SqlDbType.NVarChar, 50);
            param.Value = UserName;
            DataTable dt = Data.selectData("LastSeen", param);
            Laccess = dt.Rows[0]["date_of_access"].ToString();
            Lseen = dt.Rows[0]["date_of_leave"].ToString();

        }

        #endregion
    }
}
