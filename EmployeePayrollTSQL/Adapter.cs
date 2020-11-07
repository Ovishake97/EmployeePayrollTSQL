using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EmployeePayrollTSQL
{
   public class Adapter
    {
        public static string connectionString = "Server=(localdb)\\MSSQLLocalDB; Initial Catalog =payroll_ado; User ID = AkSharma; Password=abhishek123";
        public SqlConnection connection = new SqlConnection(connectionString);
        public bool AddEmployee()
        {
            using (connection)
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();

                try
                {
                    command.CommandText =
                      "insert into Employee_Payroll(name,gender,salaryid) values('Mohit','M',112)";
                   int numberOfAffectedRows= command.ExecuteNonQuery();
                    if (numberOfAffectedRows != 0)
                    {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
