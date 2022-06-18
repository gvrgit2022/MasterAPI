using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;
using Org.BouncyCastle.Crypto.Tls;
using Master.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Master.Application.Address.Model;
using Master.Infrastructure.Models.Address;

namespace Master.Application.Admission.Commands
{
    public class AdmissionTypeCommand : IRequest<string>, INotification
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
        public DateTime Createdate { get; set; }
        public DateTime? Enddate { get; set; }
        public int Status { get; set; }
        public int Blocked { get; set; }
        public int Userid { get; set; }
        public int Routid { get; set; }
        public string? Workstationid { get; set; }
        public string? Name2l { get; set; }
        public DateTime Rowseq { get; set; }
        public int FacilityId { get; set; }
        public int? Dspk { get; set; }

        public class AdmissionTypeCommandHandler : BaseHandler, IRequestHandler<AdmissionTypeCommand, string>
        {
            public AdmissionTypeCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(AdmissionTypeCommand request, CancellationToken cancellationtoken)
            {
                var addressType = new Infrastructure.Models.Master.Admissiontype();
                addressType.Id = request.Id;
                addressType.Name = request.Name;
                addressType.Name2l = request.Name2l;
                addressType.Code = request.Code;
                addressType.Workstationid = request.Workstationid;
                addressType.Rowseq = request.Rowseq;
                addressType.Dspk = request.Dspk;
                addressType.Status = request.Status;
                addressType.Createdate = request.Createdate;
                addressType.Routid = request.Routid;
                addressType.Userid = request.Userid;
                addressType.Enddate = request.Enddate;
                masterContext.Add(addressType);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
} 
