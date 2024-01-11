using System.Linq;
using AutoMapper;
using SS.Template.Application.Features.Interviews.Commands;
using SS.Template.Application.Features.TechSkills.Commands;
using SS.Template.Domain.Entities;

namespace SS.Template.Application.Features.Interviews
{
    public sealed class InterviewsMapping : Profile
    {
        public InterviewsMapping()
        {
            CreateMap<AddInterviewsModel, Interview>()
                .ForMember(x => x.Id, e => e.Ignore());

            CreateMap<AddTechSkillsModel, TechSkill>();

            CreateMap<Interview, InterviewsModel>()
                .ForMember(x => x.CV, e => e.MapFrom(src => src.CV.Split('\\', System.StringSplitOptions.None).LastOrDefault()));

        }


    }
}
