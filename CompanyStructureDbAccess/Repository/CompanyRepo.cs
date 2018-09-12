using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Linq;
using Dapper;
using CompanyStructureDbAccess.Model;

namespace CompanyStructureDbAccess.Repository
{

    public class CompanyRepo
    {

        public List<Model.Company> Read(SqlConnection conn)
        {
            string sqlStatement = @"SELECT Id,
                                            Company AS Name
                                    FROM viCompany;";
            var result = conn.Query<Company>(sqlStatement).ToList();
            return result;
        }

        public bool CreateOrUpdate(SqlConnection conn, string Name)
        {
            string query = "spCreateOrUpdateCompany";
            var param = new DynamicParameters();
            param.Add("@Name", Name);
            var result = conn.Execute(query, param, null, null, CommandType.StoredProcedure);
            return result > 0;
        }






    }
}
