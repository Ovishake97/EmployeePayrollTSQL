using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTest
{
    [TestClass]
    public class UnitTest1
    {
        EmployeePayrollTSQL.Adapter adapter = null;
        [TestInitialize]
        public void SetUp() {
            adapter = new EmployeePayrollTSQL.Adapter();
        }
        /// Checking whether any employee is added or not
        [TestMethod]
        public void InsertQueryAddsIntoEmployeeTable() {
            bool result = adapter.AddEmployee();
            Assert.IsTrue(result);
        }
        //Checking whether the datas are added to the two rows or not
        [TestMethod]
        public void InsertQueryAddsIntoEmployeeAndSalaryTable() {
            string expected = "Both records were written to database.";
            string actual = adapter.AddEmployeeAndSalary();
            Assert.AreEqual(actual, expected);
        }
    }
}
