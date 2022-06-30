using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.CityAreas.Commands
{
    public class CityAreaCommand : IRequest<string>, INotification
    {
        public int CityAreaId { get; set; }
        public int CityId { get; set; }
        public string Area { get; set; } = null!;
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public int? ZoneId { get; set; }
        public string? Area2L { get; set; }
        public DateTime Rowseq { get; set; }
        public int? Dspk { get; set; }

        public class CityAreaTypeCommandHandler : BaseHandler, IRequestHandler<CityAreaCommand, string>
        {
            public CityAreaTypeCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(CityAreaCommand request, CancellationToken cancellationtoken)
            {
                var cityarea = new Infrastructure.Models.Master.Cityarea();
                cityarea.CityAreaId = request.CityAreaId;
                cityarea.CityId = request.CityId;
                cityarea.Area = request.Area;
                cityarea.Code = request.Code;
                cityarea.Createdate = request.Createdate;
                cityarea.Enddate = request.Enddate;
                cityarea.Status = request.Status;
                cityarea.Blocked = request.Blocked;
                cityarea.Routid = request.Routid;
                cityarea.Userid = request.Userid;
                cityarea.Workstationid = request.Workstationid;
                cityarea.ZoneId = request.ZoneId;
                cityarea.Rowseq = request.Rowseq;
                cityarea.Dspk = request.Dspk;
                cityarea.Area2L = request.Area2L;
                masterContext.Add(cityarea);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
