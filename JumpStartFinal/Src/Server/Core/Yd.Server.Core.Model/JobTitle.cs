using System.Collections.Generic;

namespace Yd.Server.Core.Model
{
    public class JobTitle
    {
        public int JobTitleId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
