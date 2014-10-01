using System;

namespace Yd.Server.Core.Model
{
    public class Vaccation
    {
        public int VaccationId { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VaccationStatus VaccationStatus { get; set; }
        public DateTime CreatedDate { get; set; }
       
    }
}
