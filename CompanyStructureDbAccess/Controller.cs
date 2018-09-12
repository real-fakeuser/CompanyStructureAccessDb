using CompanyStructureDbAccess.Repository;
using CompanyStructureDbAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureDbAccess
{
    public static class Globals
    {
        public static string ConnString = Properties.Settings.Default.SqlConnString;
    }

    class Controller
    {
        public static void run()
        {
            // Get and print Company table 
            CompanyRepo companyRepo = new CompanyRepo();
            CompanyRepo.show();












            Console.ReadLine();
        }
    }
}