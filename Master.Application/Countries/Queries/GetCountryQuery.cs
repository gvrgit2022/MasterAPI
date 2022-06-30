using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.Countries.Model;
using MediatR;
using Country = Master.Application.Countries.Model.Country;

namespace Master.Application.Countries.Queries
{
    public class GetCountryQuery : IRequest<Country>
    {
        public int Id { get; set; }

    }
    public class GetCountryQueryQueryHandler : BaseHandler, IRequestHandler<GetCountryQuery, Country>
    {
        public GetCountryQueryQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<Country> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var country = await masterContext.Countries

           .ProjectTo<Country>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return country;
        }
    }

}

