using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Locations.Commands
{
    public class LocationCommand : IRequest<string>, INotification
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

        public class LocationCommandHandler : BaseHandler, IRequestHandler<LocationCommand, string>
        {
            public LocationCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(LocationCommand request, CancellationToken cancellationtoken)
            {
                var locationtype = new Infrastructure.Models.Master.Locationtype();
                locationtype.LocationtypeId = request.LocationtypeId;
                locationtype.Location = request.Location;
                locationtype.Code = request.Code;
                locationtype.Createdate = request.Createdate;
                locationtype.Modifydate = request.Modifydate;
                locationtype.Blocked = request.Blocked;
                locationtype.Workstationid = request.Workstationid;
                locationtype.Rowseq = request.Rowseq;
                locationtype.Dspk = request.Dspk;
                masterContext.Add(locationtype);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
