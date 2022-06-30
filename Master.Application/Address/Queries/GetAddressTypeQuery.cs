using MediatR;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Master.Application.Address.Model;
using Master.Infrastructure.Models.Master;
using Addresstype = Master.Application.Address.Model.Addresstype;
 

namespace Master.Application.Address.Queries
{ 
public class GetAddressTypeQuery : IRequest<Addresstype>
{
	//Query filter paramters
	[Required]
	public int AddressTypeId { get; set; }

    }
    public class GetAddressTypeQueryHandler : BaseHandler, IRequestHandler<GetAddressTypeQuery, Addresstype>
    {
        public GetAddressTypeQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }

        public async Task<Addresstype> Handle(GetAddressTypeQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var addrType = await masterContext.Addresstypes 
                 .Where(c => c.AddressTypeId == request.AddressTypeId)
               .ProjectTo<Addresstype>(ConfigurationProvider)
               .FirstOrDefaultAsync(cancellationToken);
            return addrType;
        }
    }
}