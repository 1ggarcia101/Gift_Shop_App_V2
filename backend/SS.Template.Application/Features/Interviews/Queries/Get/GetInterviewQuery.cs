using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Application.Queries;

namespace SS.Template.Application.Features.Interviews.Queries.Get
{
    public class GetInterviewQuery : IQuery<InterviewsModel>
    {
        public Guid Id { get; }

        public GetInterviewQuery(Guid id)
        {
            Id = id;
        }
    }
}
