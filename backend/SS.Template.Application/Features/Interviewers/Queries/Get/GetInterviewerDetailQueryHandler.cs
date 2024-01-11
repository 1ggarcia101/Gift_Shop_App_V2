using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SS.Template.Application.Features.Examples.Queries.Get;
using SS.Template.Application.Features.Examples;
using SS.Template.Application.Queries;
using SS.Template.Core.Exceptions;
using SS.Template.Core.Persistence;
using SS.Template.Domain.Entities;
using SS.Template.Domain.Model;
using AutoMapper.QueryableExtensions;

namespace SS.Template.Application.Features.Interviewers.Queries.Get
{
    public class GetInterviewerDetailQueryHandler : IQueryHandler<GetInterviewerDetailQuery, InterviewerModel>
    {
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IMapper _mapper;

        public GetInterviewerDetailQueryHandler(IReadOnlyRepository readOnlyRepository, IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
        }

        public async Task<InterviewerModel> Handle(GetInterviewerDetailQuery request, CancellationToken cancellationToken)
        {
            var query = _readOnlyRepository.Query<Domain.Entities.Interviewers>(x => x.Id == request.Id && x.Status == EnabledStatus.Enabled)
                .ProjectTo<InterviewerModel>(_mapper.ConfigurationProvider);

            var result = await _readOnlyRepository.SingleAsync(query, cancellationToken);

            if (result == null)
            {
                throw EntityNotFoundException.For<Domain.Entities.Interviewers>(request.Id);
            }

            return result;
        }
    }
}
