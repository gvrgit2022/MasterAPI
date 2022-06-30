using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Master.Infrastructure.Models.Master;
using Master.Application.Departments.Models;
using MediatR;
using Department = Master.Application.Departments.Models.Department;

namespace Master.Application.Departments.Queries
{
    public class GetDepartmentQuery : IRequest<Department>
    {
        public int Id { get; set; }

    }
    public class GetDepartmentQueryHandler : BaseHandler, IRequestHandler<GetDepartmentQuery, Department>
    {
        public GetDepartmentQueryHandler(MasterContext tcontext, IMapper mapper) : base(tcontext, mapper) { }
        
        public async Task<Department> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            //var samples = await testContext.TutorialsTbls.Select
            //  .FirstOrDefaultAsync(cancellationToken);

            var department = await masterContext.Departments

           .ProjectTo<Department>(ConfigurationProvider)
           .FirstOrDefaultAsync(cancellationToken);
            return department;
        }
    }

}

