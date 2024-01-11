
using AutoMapper;
using SS.Template.Application.Features.DesirableSkills.Commands;
using SS.Template.Domain.Entities;

namespace SS.Template.Application.Features.DesirableSkills
{
    public sealed class DesirableSkillsMapping : Profile
    {
        public DesirableSkillsMapping()
        {
            CreateMap<AddDesirableSkillsModel, DesirableSkill>()
                .ForMember(x => x.Id, e => e.Ignore());

            CreateMap<DesirableSkill, DesirableSkillsModel>();
        }
    }
}
