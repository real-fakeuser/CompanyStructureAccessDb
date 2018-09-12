using CompanyStructureDbAccess.Repository;
using CompanyStructureDbAccess.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CompanyStructureDbAccess
{
    class MainLogic
    {
        public static void run()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Properties.Settings.Default.SqlConnString;
            CompanyController CC = new CompanyController();
            CC.ctrl(conn);


            Console.ReadLine();
        }
    }
}