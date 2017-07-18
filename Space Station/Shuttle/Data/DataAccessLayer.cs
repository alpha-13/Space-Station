using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows;

namespace Shuttle.Data
{
    class DataAccessLayer
    {
        SqlConnection conn;

        public DataAccessLayer()
        {
            conn = new SqlConnection(@"Server=THE-SNIPER\ME; Database=Space_Shuttle; Integrated Security=true");
        }

        public DataAccessLayer(string DataBase)
        {
            conn = new SqlConnection(@"Server=THE-SNIPER\ME; Database=" + DataBase + "; Integrated Security=true");

        }

        private void open()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
            }
            catch
            {
                MessageBox.Show("Sorry Data Base Failed ! :( \nPlease Contact The Programmer of this system :) \n Thank You", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Process.GetCurrentProcess().Kill();
            }
        }

        private void close()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch
            {
                MessageBox.Show("Sorry Data Base Failed ! :( \nPlease Contact The Programmer of this system :) \n Thank You", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Process.GetCurrentProcess().Kill();
            }
        }

        public DataTable selectData(string stored_procedure, params SqlParameter[] param)
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = stored_procedure;
                sqlcmd.Connection = conn;

                if (param != null)
                    sqlcmd.Parameters.AddRange(param);
                open();
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                close();
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                MessageBox.Show("Sorry There is a problem in data base command :( \nPlease Contact The Programmer of this system :) \n Thank You", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Process.GetCurrentProcess().Kill();
                return null;
            }
        }

        public void ExecuteCommand(string stored_procedure, params SqlParameter[] param)
        {
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = stored_procedure;
                sqlcmd.Connection = conn;

                if (param != null)
                    sqlcmd.Parameters.AddRange(param);
                open();
                sqlcmd.ExecuteNonQuery();
                close();
            }
            catch
            {
                MessageBox.Show("Sorry There is a problem in data base command :( \nPlease Contact The Programmer of this system :) \n Thank You", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}
