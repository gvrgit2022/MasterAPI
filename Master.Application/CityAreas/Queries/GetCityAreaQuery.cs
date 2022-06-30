using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.CityAreas.Models;
using MediatR;
using CityArea = Master.Application.CityAreas.Models.Cityarea;

namespace Master.Application.CityAreas.Queries
{
    public class GetCityAreaQuery : IRequest<CityArea>
    {
        public int Id { get; set; }

    }
    public class GetCityAreaQueryHandler : BaseHandler, IRequestHandler<GetCityAreaQuery, CityArea>
    {
        public GetCityAreaQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<CityArea> Handle(GetCityAreaQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var cityarea = await masterContext.Cityareas

           .ProjectTo<CityArea>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return cityarea;
        }
    }

}

