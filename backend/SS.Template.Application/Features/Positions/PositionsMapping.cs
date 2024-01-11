
using AutoMapper;
using SS.Template.Domain.Entities;
using SS.Template.Application.Features.Positions.Commands;
using SS.Template.Application.Features.TechnicalKnowledge;
using SS.Template.Application.Features.TechnicalKnowledge.Commands;
using SS.Template.Application.Features.SoftSkills.Commands;
using SS.Template.Application.Features.JobDescription.Commands;
using SS.Template.Application.Features.SpecificWorkExperienceRequirements.Commands;
using SS.Template.Application.Features.DesirableSkills.Commands;

namespace SS.Template.Application.Features.Positions
{
    public sealed class PositionsMapping : Profile
    {
        public PositionsMapping()
        {
            CreateMap<AddPositionsModel, Position>()
                .ForMember(x => x.Id, e => e.Ignore());

            CreateMap<AddTechnicalKnowledgeModel, TechnicalKnowledges>();

            CreateMap<AddSoftSkillsModel, SoftSkill>();

            CreateMap<AddJobDescriptionModel, JobDescriptions>();

            CreateMap<AddSpecificWorkExperienceRequirementsModel, SpecificWorkExperienceRequirement>();

            CreateMap<AddDesirableSkillsModel, DesirableSkill>();

            CreateMap<Position, PositionsModel>();
        }
    }
}
