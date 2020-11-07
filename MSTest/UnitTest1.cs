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
    }
}
