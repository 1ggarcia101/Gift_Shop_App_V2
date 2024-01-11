using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Template.Core;
using SS.Template.Domain.Entities;

namespace SS.Template.Persistence.Configurations
{
    public sealed class TechSkillConfiguration : IEntityTypeConfiguration<TechSkill>
    {
        public void Configure(EntityTypeBuilder<TechSkill> builder)
        {

        }
    }
}
