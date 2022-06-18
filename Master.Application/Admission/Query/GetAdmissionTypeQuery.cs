
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Master.Application.Admission.Model;
using Master.Infrastructure.Models.Master;
using MediatR;

namespace Master.Application.Admission.Query
{
    public class GetAdmissionTypeQuery : IRequest<AdmissionType>
    {
        public int Id { get; set; }

    }
    public class GetAdmissionTypeQueryQueryHandler : BaseHandler, IRequestHandler<GetAdmissionTypeQuery, AdmissionType>
    {
        public GetAdmissionTypeQueryQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }

        public async Task<AdmissionType> Handle(GetAdmissionTypeQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var addrType = await masterContext.Admissiontypes
                 
               .ProjectTo<AdmissionType>(ConfigurationProvider)
               .FirstOrDefaultAsync(cancellationToken);
            return addrType;
        }
    }
}
