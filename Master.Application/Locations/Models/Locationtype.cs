using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Application.Locations.Models
{
    public class Locationtype
    {
        public sbyte LocationtypeId { get; set; }
        public string? Location { get; set; }
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Modifydate { get; set; }
        public sbyte? Blocked { get; set; }
        public DateTime Rowseq { get; set; }
        public string? Workstationid { get; set; }
        public int? Dspk { get; set; }
    }
}
