using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.Amenities.Model;
using MediatR;
using Amenity = Master.Application.Amenities.Model.Amenity;

namespace Master.Application.Amenities.Queries
{
    public class GetAmenitiesQuery : IRequest<Amenity>
    {
        public int Id { get; set; }

    }
    public class GetAmenitiesQueryHandler : BaseHandler, IRequestHandler<GetAmenitiesQuery, Amenity>
    {
        public GetAmenitiesQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<Amenity> Handle(GetAmenitiesQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var amenity = await masterContext.Amenities

           .ProjectTo<Amenity>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return amenity;
        }
    }

}

