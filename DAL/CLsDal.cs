using IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DAL
{
    public class CLsDAL : IDAL
    {

        private readonly IConfiguration _configuration;

        public CLsDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection");
        }
        public bool Execute(SqlCommand cmd)
        {
            bool result = false;
            string connectionString = GetConnectionString();
            SqlConnection con = new SqlConnection(connectionString);


            try
            {
                if (con.State != ConnectionState.Open)
                {

                    con.Open();
                }
                cmd.Connection = con;

                if (cmd.ExecuteNonQuery() > 0)
                {


                    result = true;
                }

            }
            catch (Exception ex)
            {



            }
            finally
            {
                cmd.Dispose();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return result;
        }

        public DataTable GetData(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            string ConnectionString = GetConnectionString();

            SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                cmd.Connection = conn;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
                dr.Dispose();

            }
            catch (Exception ex) { }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return dt;
        }
    }
}