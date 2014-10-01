using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yd.Server.Core.Model
{
    public class EmployeePicture
    {
        public int EmployeePictureId { get; set; }

        public PictureType PictureType { get; set; }
      
        public byte[] Content { get; set; }
        public int? EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
