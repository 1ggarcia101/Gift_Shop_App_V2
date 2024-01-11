using AutoMapper;
using SS.Template.Application.Features.Examples.Commands;
using SS.Template.Domain.Entities;

namespace SS.Template.Application.Features.Examples
{
    public sealed class ExamplesMapping : Profile
    {
        public ExamplesMapping()
        {
            CreateMap<AddExampleModel, Example>()
                .ForMember(x => x.Id, e => e.Ignore());

            CreateMap<Example, ExampleModel>();
        }
    }
}
