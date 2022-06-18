using MasterAPI.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.Application.Address.Model
{
    public class Addresstype:BaseModel    {
        public int AddressTypeId { get; set; }
        public string? AddressType1 { get; set; }
        public DateTime? Createdate { get; set; }
        public DateTime? Moddate { get; set; }
        public DateTime? Enddate { get; set; }
        public bool? Status { get; set; }
        public bool? Blocked { get; set; }
        public int? UserId { get; set; }
        public string? Workstationid { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }
    }
}
