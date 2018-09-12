using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyStructureDbAccess.Repository;
using CompanyStructureDbAccess.Model;


namespace CompanyStructureDbAccess.Controller
{
    class CompanyController
    {
        public void ctrl(SqlConnection conn)
        {
            CompanyRepo CR = new CompanyRepo();
            CR.Read(conn);
            CR.CreateOrUpdate(conn, "testcompany");
            Console.ReadLine();
        }
    }
}
