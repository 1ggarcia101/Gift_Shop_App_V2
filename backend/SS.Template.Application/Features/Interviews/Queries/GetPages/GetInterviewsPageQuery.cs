using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Application.Queries;

namespace SS.Template.Application.Features.Interviews.Queries.GetPage
{
    public sealed class GetInterviewsPageQuery : PaginatedQuery<InterviewsModel>
    {
        public DateTime? starDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
