using System;

namespace Yd.Server.Core.Model
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
