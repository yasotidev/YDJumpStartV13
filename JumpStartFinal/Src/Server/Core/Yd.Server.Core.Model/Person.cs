using System.Collections.Generic;

namespace Yd.Server.Core.Model
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
