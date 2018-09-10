using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CompanyStructureDbAccess
{
    class Program
    {
        static void Main(string[] args)
        {

            OpenSqlConnection();
            //Console.WriteLine(OpenSqlConnection());
            Console.ReadKey();


        }

        private static void OpenSqlConnection()
        {
            string connectionString = GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                Console.WriteLine("State: {0}", connection.State);
            }
        }

        static private string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file, using the 
            // System.Configuration.ConfigurationSettings.AppSettings property 
            return "Data Source=TAPPQA;Initial Catalog=Training-TN-CompanyStructure;"
                + "Integrated Security=True;";
        }




        public static SqlDataAdapter CreateCustomerAdapter(
                SqlConnection connection)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Create the SelectCommand.
                SqlCommand command = new SqlCommand("SELECT * FROM Customers " +
                    "WHERE Country = @Country AND City = @City", connection);

                // Add the parameters for the SelectCommand.
                command.Parameters.Add("@Country", SqlDbType.NVarChar, 15);
                command.Parameters.Add("@City", SqlDbType.NVarChar, 15);

                adapter.SelectCommand = command;

                // Create the InsertCommand.9
                command = new SqlCommand(
                    "INSERT INTO Customers (CustomerID, CompanyName) " +
                    "VALUES (@CustomerID, @CompanyName)", connection);

                // Add the parameters for the InsertCommand.
                command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID");
                command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName");

                adapter.InsertCommand = command;

                // Create the UpdateCommand.
                command = new SqlCommand(
                    "UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName " +
                    "WHERE CustomerID = @oldCustomerID", connection);

                // Add the parameters for the UpdateCommand.
                command.Parameters.Add("@CustomerID", SqlDbType.NChar, 5, "CustomerID");
                command.Parameters.Add("@CompanyName", SqlDbType.NVarChar, 40, "CompanyName");
                SqlParameter parameter = command.Parameters.Add(
                    "@oldCustomerID", SqlDbType.NChar, 5, "CustomerID");
                parameter.SourceVersion = DataRowVersion.Original;

                adapter.UpdateCommand = command;

                // Create the DeleteCommand.
                command = new SqlCommand(
                    "DELETE FROM Customers WHERE CustomerID = @CustomerID", connection);

                // Add the parameters for the DeleteCommand.
                parameter = command.Parameters.Add(
                    "@CustomerID", SqlDbType.NChar, 5, "CustomerID");
                parameter.SourceVersion = DataRowVersion.Original;

                adapter.DeleteCommand = command;

                return adapter;
            }
        
            
    }
}
