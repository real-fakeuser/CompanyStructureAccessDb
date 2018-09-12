using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Linq;

namespace CompanyStructureDbAccess.Repository
{

public class CompanyRepo
    {
        
        public static int create()
        {



            return Convert.ToInt32(false);
        }

        public static int update()
        {



            return Convert.ToInt32(false);
        }

        public static int delete()
        {



            return Convert.ToInt32(false);
        }
        public static int show()
        {

            string connectionString = Globals.ConnString;


                SqlConnection connection = new SqlConnection(connectionString);

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = queryString;

                DataTable data = new DataTable();


                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);
//                return data;
                



            return Convert.ToInt32(false);
        }







    }
}
