using System.Collections.Generic;

namespace Yd.Server.Core.Model
{
    public class Team
    {      
        public int TeamId { get; set; }
        public int? ManagerId { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
