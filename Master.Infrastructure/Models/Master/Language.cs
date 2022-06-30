using System;
using System.Collections.Generic;

namespace Master.Infrastructure.Models.Master
{
    /// <summary>
    /// Languages master table
    /// </summary>
    public partial class Language
    {
        public int LanguageId { get; set; }
        public string Language1 { get; set; } = null!;
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? Language2L { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }
    }
}
