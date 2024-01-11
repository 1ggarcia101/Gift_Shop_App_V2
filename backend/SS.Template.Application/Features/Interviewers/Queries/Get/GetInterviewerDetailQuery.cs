using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Application.Queries;

namespace SS.Template.Application.Features.Interviewers.Queries.Get
{
    public class GetInterviewerDetailQuery : IQuery<InterviewerModel>
    {
        public Guid Id { get; }
        public GetInterviewerDetailQuery(Guid id)
        {
            Id = id;

        }
    }
}
