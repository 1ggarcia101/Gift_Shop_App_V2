using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SS.Template.Application.Queries;
using SS.Template.Core.Exceptions;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Entities;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.Interviews.Queries.Get
{
    public sealed class GetInterviewQueryHandler : IQueryHandler<GetInterviewQuery, InterviewsModel>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;

        public GetInterviewQueryHandler(IReadOnlyRepository readOnlyRepository, IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
        }

        public async Task<InterviewsModel> Handle(GetInterviewQuery request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepository.Query<Interview>(x => x.Id == request.Id && x.Status == EnabledStatus.Enabled)
                .ProjectTo<InterviewsModel>(_mapper.ConfigurationProvider);

            var result = await _readOnlyRepository.SingleAsync(query, cancellationToken);

            if (result == null)
            {
                throw EntityNotFoundException.For<Interview>(request.Id);
            }

            return result;
        }
    }
}
