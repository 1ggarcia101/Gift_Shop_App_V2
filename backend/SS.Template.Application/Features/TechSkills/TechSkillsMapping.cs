using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SS.Template.Application.Features.TechSkills.Commands;
using SS.Template.Domain.Entities;

namespace SS.Template.Application.Features.TechSkills
{
    public sealed class TechSkillsMapping : Profile
    {
        public TechSkillsMapping()
        {
            CreateMap<AddTechSkillsModel, TechSkill>()
                .ForMember(x => x.Id, e => e.Ignore());

            CreateMap<TechSkill, TechSkillsModel>();
        }
    }
}
