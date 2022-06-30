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
using Master.Infrastructure.Models;

namespace Master.Application.Address.Commands
{
    public class AddressTypeCommand : IRequest<string>, INotification
    {
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

        public class AddressTypeCommandHandler : BaseHandler, IRequestHandler<AddressTypeCommand, string>
        {
            public AddressTypeCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(AddressTypeCommand request, CancellationToken cancellationtoken)
            {
                var addressType = new Infrastructure.Models.Master.Addresstype();
                addressType.AddressType1 = request.AddressType1;
                addressType.AddressTypeId = request.AddressTypeId;
                addressType.UserId = request.UserId;
                addressType.Workstationid = request.Workstationid;
                addressType.Rowseq = request.Rowseq;
                addressType.Dspk = request.Dspk;
                addressType.Status = request.Status;
                addressType.Createdate = request.Createdate;
                addressType.Moddate = request.Moddate;
                addressType.Enddate = request.Enddate;
                masterContext.Add(addressType);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
} 
