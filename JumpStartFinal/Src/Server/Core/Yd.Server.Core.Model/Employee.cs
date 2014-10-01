using System;
using System.Collections.Generic;

namespace Yd.Server.Core.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int? PersonId { get; set; }
        public virtual Person Person { get; set; }
        public DateTime HireDate { get; set; }
        public int? JobTitleId { get; set; }
        public virtual JobTitle JobTitle { get; set; }
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<EmployeePicture> EmployeePictures { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Vaccation> Vaccations { get; set; }
    }
}
