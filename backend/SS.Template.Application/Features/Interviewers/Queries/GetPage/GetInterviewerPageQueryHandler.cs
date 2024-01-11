using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SS.Template.Application.Infrastructure;
using SS.Template.Application.Queries;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.Interviewers.Queries.GetPage
{
    public class GetInterviewerPageQueryHandler : IQueryHandler<GetInterviewersPageQuery, PaginatedResult<InterviewerModel>>
    {
        private readonly IReadOnlyRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPaginator _paginator;
        public GetInterviewerPageQueryHandler(IReadOnlyRepository repository, IMapper mapper, IPaginator paginator)
        {
            _repository = repository;
            _mapper = mapper;
            _paginator = paginator;

        }
        public async Task<PaginatedResult<InterviewerModel>> Handle(GetInterviewersPageQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.Query<Domain.Entities.Interviewers>(x => x.ActiveInterviewer == EnabledStatus.Enabled);
            if (!string.IsNullOrEmpty(request.Term))
            {
                var term = request.Term.ToUpper();
                query = query.Where(x=>x.DisplayName.ToUpper().Contains(term));
            }
            var sortCriteria = request.GetSortCriteria();
            var items = query
                .ProjectTo<InterviewerModel>(_mapper.ConfigurationProvider)
                .OrderByOrDefault(sortCriteria, x => x.DisplayName);


            var page = await _paginator.MakePageAsync(_repository, query, items, request, cancellationToken);

            return page;
        }
    }
}
