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
        /// Adding new employee to the employee table
        /// and returning true if any number of rows are affected
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
        /// Adds datas to the employee table as well as to the salary table
        public string AddEmployeeAndSalary()
        {
            using (connection)
            {
                connection.Open();

                // Start a local transaction.
                SqlTransaction sqlTran = connection.BeginTransaction();

                // Enlist a command in the current transaction.
                SqlCommand command = connection.CreateCommand();
                command.Transaction = sqlTran;

                try
                {
                    // Execute two separate commands.
                    command.CommandText =
                      "insert into Employee_Payroll(name,gender,salaryid) values('Mohit','M',112)";
                    command.ExecuteScalar();
                    command.CommandText =
                      "insert into Payroll_Details(salaryid,salary) values(112,11080.9)";
                     command.ExecuteNonQuery();
                    sqlTran.Commit();
                    return "Both records were written to database.";
                }
                catch (Exception ex)
                {

                    try
                    {
                        sqlTran.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        throw new Exception(exRollback.Message);
                    }
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
