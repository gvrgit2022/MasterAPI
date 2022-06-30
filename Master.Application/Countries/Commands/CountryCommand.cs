using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Countries.Commands
{
    public class CountryCommand : IRequest<string>, INotification
    {
        public int CountryId { get; set; }
        public string Country1 { get; set; } = null!;
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? Country2L { get; set; }
        public DateTime Rowseq { get; set; }
        public DateTime? Moddate { get; set; }
        public int? Dspk { get; set; }

        public class CountryCommandHandler : BaseHandler, IRequestHandler<CountryCommand, string>
        {
            public CountryCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(CountryCommand request, CancellationToken cancellationtoken)
            {
                var countriestype = new Infrastructure.Models.Master.Country();
                countriestype.CountryId = request.CountryId;
                countriestype.Country1 = request.Country1;
                countriestype.Code = request.Code;
                countriestype.Createdate = request.Createdate;
                countriestype.Enddate = request.Enddate;
                countriestype.Status = request.Status;
                countriestype.Blocked = request.Blocked;
                countriestype.Routid = request.Routid;
                countriestype.Userid = request.Userid;
                countriestype.Workstationid = request.Workstationid;
                countriestype.Rowseq = request.Rowseq;
                countriestype.Moddate = request.Moddate;
                countriestype.Dspk = request.Dspk;
                countriestype.Country2L = request.Country2L;
                masterContext.Add(countriestype);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
