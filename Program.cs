using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataRead
{
    internal class Program
    {

        //string cs = ConfigurationManager.ConnectionStrings["data_read"].ConnectionString;

        static void Main(string[] args)
        {
            Program.AllEmployeeDetail();
            
        }
        static void AllEmployeeDetail()
        {
            string cs = ConfigurationManager.ConnectionStrings["data_read"].ConnectionString;
            SqlConnection con = null;
            try
            {
                using(con = new SqlConnection(cs))
                {
                    string query = "select * from crud";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Console.WriteLine("ID " + dr["id"] + " Name " + dr["name"] + " Mobo No " + dr["mobono"] + " address " + dr["address"] + " Capname " + dr["capname"]);
                    }
                }
            }
            catch(SqlException ee)
            {
                Console.WriteLine(ee.Message);
            }
            finally
            {
                con.Close();
            }

        }
    }
}
