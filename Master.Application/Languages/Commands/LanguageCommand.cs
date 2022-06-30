using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Languages.Commands
{
    public class LanguageCommand : IRequest<string>, INotification
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

        public class LanguageCommandHandler : BaseHandler, IRequestHandler<LanguageCommand, string>
        {
            public LanguageCommandHandler(MasterContext hcontext, IMapper mapper) : base(hcontext, mapper)
            { }
            public async Task<string> Handle(LanguageCommand request, CancellationToken cancellationtoken)
            {
                var languagetype = new Infrastructure.Models.Master.Language();
                languagetype.LanguageId = request.LanguageId;
                languagetype.Language1 = request.Language1;
                languagetype.Code = request.Code;
                languagetype.Createdate = request.Createdate;
                languagetype.Enddate = request.Enddate;
                languagetype.Status = request.Status;
                languagetype.Blocked = request.Blocked;
                languagetype.Routid = request.Routid;
                languagetype.Userid = request.Userid;
                languagetype.Workstationid = request.Workstationid;
                languagetype.Language2L = request.Language2L;
                languagetype.Rowseq = request.Rowseq;
                languagetype.Dspk = request.Dspk;
                masterContext.Add(languagetype);
                await masterContext.SaveChangesAsync();
                return "Success";
            }
        }
    }
}
