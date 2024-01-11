using System;
using System.IO;
using SS.Template.Application.Queries;

namespace SS.Template.Application.Features.Interviews.Queries.GetCVPDF
{
    public class GetInterviewCVPDFQuery : IQuery<MemoryStream>
    {
        public Guid Id { get; set; }
        public GetInterviewCVPDFQuery(Guid id)
        {
            Id = id;

        }
    }
}
