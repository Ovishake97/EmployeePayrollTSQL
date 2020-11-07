using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayrollTSQL
{
  public  class SalaryModel
    {
        public int SalaryId { get; set; }
        public decimal basicPay { get; set; }
        public decimal deduction { get; set; }
        public decimal taxablePay { get; set; }
        public decimal incomeTax { get; set; }
        public decimal netPay { get; set; }
    }
}
