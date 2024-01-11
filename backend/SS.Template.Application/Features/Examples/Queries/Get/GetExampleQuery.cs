using System;
using SS.Template.Application.Features.Examples;
using SS.Template.Application.Queries;

namespace SS.Template.Application.Features.Examples.Queries.Get
{
    public class GetExampleQuery : IQuery<ExampleModel>
    {
        public Guid Id { get; }

        public GetExampleQuery(Guid id)
        {
            Id = id;
        }
    }
}
