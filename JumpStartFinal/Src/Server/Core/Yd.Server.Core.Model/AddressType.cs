using System;
using System.Collections.Generic;

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
