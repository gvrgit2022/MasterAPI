using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Amenities.Commands
{
    public class AmenityCommand : IRequest<string>, INotification
    {
        public int AmenitieId { get; set; }
        public string? Amenitie { get; set; }
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? Amenitie2L { get; set; }
        public DateTime Rowseq { get; set; }
        public DateTime Moddate { get; set; }
        public int? Dspk { get; set; }


        public class AmenityCommandHandler : BaseHandler, IRequestHandler<AmenityCommand, string>
        {
            public AmenityCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(AmenityCommand request, CancellationToken cancellationtoken)
            {
                var amenity = new Infrastructure.Models.Master.Amenity();
                amenity.AmenitieId = request.AmenitieId;
                amenity.Amenitie = request.Amenitie;
                amenity.Code = request.Code;
                amenity.Createdate = request.Createdate;
                amenity.Enddate = request.Enddate;
                amenity.Status = request.Status;
                amenity.Blocked = request.Blocked;
                amenity.Routid = request.Routid;
                amenity.Userid = request.Userid;
                amenity.Workstationid = request.Workstationid;
                amenity.Amenitie2L = request.Amenitie2L;
                amenity.Rowseq = request.Rowseq;
                amenity.Dspk = request.Dspk;
                masterContext.Add(amenity);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
