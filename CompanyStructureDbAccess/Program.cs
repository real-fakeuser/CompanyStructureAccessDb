using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Linq;

namespace CompanyStructureDbAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            //string ConnString = "Data Source=TAPPQA;Initial Catalog=Training-TN-CompanyStructure;Integrated Security=True";
            string ConnString = Properties.Settings.Default.SqlConnString;
            string dividerLine = "--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
            PrintData(ConnString, (ReadData(ConnString, "SELECT Id," +
                "                                               Street, " +
                "                                               ZipCode, " +
                "                                               City, " +
                "                                               CountryCode " +
                "                                               FROM viAddress")));
            Console.WriteLine(dividerLine);
            PrintData(ConnString, (ReadData(ConnString, "SELECT Id," +
                "                                               Company," +
                "                                               Street," +
                "                                               ZipCode," +
                "                                               City," +
                "                                               CountryCode" +
                "                                               FROM viCompany")));
            Console.WriteLine(dividerLine);
            PrintData(ConnString, (ReadData(ConnString, "SELECT Id," +
                "                                               Company," +
                "                                               Department," +
                "                                               Manager" +
                "                                               FROM viDepartment")));
            Console.WriteLine(dividerLine);
            PrintData(ConnString, (ReadData(ConnString, "SELECT Id," +
                "                                               Employee," +
                "                                               Gender," +
                "                                               Department," +
                "                                               Company" +
                "                                               FROM viEmployee")));

            
            Console.Write("To edit or update a dataset via a sp enter sp-Name and then press enter: ");
            string spName = (Console.ReadLine());
            Console.WriteLine("Now enter the attributes one by one divided by a space: ");
            string sinput = Console.ReadLine();
            string[] stringSeparators = new string[] { " " };
            ArrayList attributes = new ArrayList();
            ArrayList attributeData = new ArrayList();
            attributes.AddRange(sinput.Split(stringSeparators, StringSplitOptions.None));
            attributeData.Clear();
            for (int i = 0; i < attributes.Count; i++)
            {
                Console.Write("Enter value for " + attributes[i] + " :");
                attributeData.Add(Console.ReadLine());
                Console.WriteLine(attributes[i]);
                Console.WriteLine(attributeData[i]);
            }

            writeData(ConnString, spName, attributes, attributeData);

            Console.ReadKey();



        }


        

        private static bool writeData(string ConnString, string spName, ArrayList attributes, ArrayList data)
        {
            SqlConnection con = new SqlConnection(ConnString);
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < attributes.Count; i++)
            {
                cmd.Parameters.AddWithValue(Convert.ToString(attributes[i]), Convert.ToString(data[i]));
            }

            con.Open();
            int k = cmd.ExecuteNonQuery();
            con.Close();

            if (k != 0)
            {
                Console.WriteLine ("Record Inserted Succesfully into the Database");
                return true;
            }
            else
            {
                Console.WriteLine("An error occured while executing the procedure. Please try again and look for typing errors.");
                return false;
            }
            
        }
        

        private static void PrintData(string ConnString, DataTable data )
        {
            DataRow[] currentRows = data.Select(null, null, DataViewRowState.CurrentRows);

            if (currentRows.Length < 1)
                Console.WriteLine("No Current Rows Found");
            else
            {
                foreach (DataColumn column in data.Columns)
                    Console.Write("\t{0, -30}", column.ColumnName);

                Console.WriteLine("\t");

                foreach (DataRow row in currentRows)
                {
                    foreach (DataColumn column in data.Columns)
                        Console.Write("\t{0, -30}", row[column]);

                    Console.WriteLine("\t");
                }
            }

        }

        private static DataTable ReadData(string connectionString, string queryString)
        {
            
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = queryString;

            DataTable data = new DataTable();


            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            return data;
            
        }

        
    


    }
}
