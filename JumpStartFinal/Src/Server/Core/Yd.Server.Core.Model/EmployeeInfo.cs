namespace Yd.Server.Core.Model
{
    public class EmployeeInfo
    {
        public int EmployeeInfoId { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int? AddressTypeId { get; set; }
        public virtual AddressType AddressType { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
