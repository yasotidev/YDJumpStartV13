using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
