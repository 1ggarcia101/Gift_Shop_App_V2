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
using SS.Template.Domain.Entities;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.Interviews.Queries.GetPage
{
    public sealed class GetInterviewsPageQueryHandler : IQueryHandler<GetInterviewsPageQuery, PaginatedResult<InterviewsModel>>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IPaginator _paginator;
        private readonly IFilterCriteria _filterCriteria;

        public GetInterviewsPageQueryHandler(IReadOnlyRepository readOnlyRepository, IMapper mapper, IPaginator paginator, IFilterCriteria filterCriteria)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
            _paginator = paginator;
            _filterCriteria = filterCriteria;
        }

        public async Task<PaginatedResult<InterviewsModel>> Handle(GetInterviewsPageQuery request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepository.Query<Interview>(x => x.Status == EnabledStatus.Enabled);

            if (!string.IsNullOrEmpty(request.Term))
            {
                var term = request.Term.ToUpper().Trim();
                query = query.Where(x => x.Name.ToUpper().Contains(term));
            }
            if (request.FilterQuery.Count>0 )
            {
                
                request.FilterQuery.ForEach(x =>
                {
                    if (!string.IsNullOrEmpty(x.Key) && x.Value.Count > 0)
                    {
                        if(x.Key != "PositionLevel")
                        {
                        
                                var listValue = x.Value.Select(y => Convert.ToInt32(y.ToString())).ToList();
                                query = query.Where(_filterCriteria.BuildDynamicExpression<Interview>(x.Key, listValue));
                            

                        }
                        else
                        {
                           
                                var listValue = x.Value.Select(y => y.ToString()).ToList();
                                query = query.Where(_filterCriteria.BuildDynamicExpression<Interview>(x.Key, listValue));
                            

                        }
                    }
                });
            }
            if(request.starDate != null)
            {
                query = query.Where(x=>x.InterviewDate >= request.starDate );
            }
            if(request.endDate != null)
            {
                query = query.Where(x => x.InterviewDate <= request.endDate);
            }
            var sortCriteria = request.GetSortCriteria();
            var items = query
                .ProjectTo<InterviewsModel>(_mapper.ConfigurationProvider)
                .OrderByOrDefault(sortCriteria, x => x.InterviewDate);
            var page = await _paginator.MakePageAsync(_readOnlyRepository, query, items, request, cancellationToken);

            return page;
        }
    }
}
