using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yd.Server.Core.Model
{
    public class AddressType
    {
        public int AddressTypeId { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        
    }
}
