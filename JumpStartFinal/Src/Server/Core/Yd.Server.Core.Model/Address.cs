using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yd.Server.Core.Model
{
    public class Address
    {
        public int AddressId { get; set; }
        public int? AddressTypeId { get; set; }
        public virtual AddressType AddressType { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
