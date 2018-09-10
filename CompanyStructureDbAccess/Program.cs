using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace CompanyStructureDbAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            string ConnString = "Data Source=TAPPQA;Initial Catalog=Training-TN-CompanyStructure;Integrated Security=True";

            DataTable Ergebniss = read(ConnString, "SELECT * FROM viCompany");
           string test = (String.Format("{0} | {1}", "val0", "val1"));
            Console.WriteLine(test);
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            /*read(ConnString, "SELECT * FROM viEmployee");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            read(ConnString, "SELECT * FROM viDepartment");
            Console.WriteLine("-------------------------------------------------------------------------------------------------");
            read(ConnString, "SELECT * FROM viAddress");*/




        }

        static DataTable read(string ConnString, string query)
        {
            using (SqlConnection conn = new SqlConnection())
            {

                conn.ConnectionString = ConnString;
//                conn.Open();
                SqlCommand viewCommand = new SqlCommand(query, conn);
                Console.Write(viewCommand);

                SqlDataAdapter adapter = new SqlDataAdapter(viewCommand);
                
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }

        }




    }
}
