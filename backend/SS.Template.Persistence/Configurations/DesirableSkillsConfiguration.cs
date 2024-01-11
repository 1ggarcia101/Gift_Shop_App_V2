
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SS.Template.Domain.Entities;

namespace SS.Template.Persistence.Configurations
{
    public sealed class DesirableSkillsConfiguration : IEntityTypeConfiguration<DesirableSkill>
    {

        public void Configure(EntityTypeBuilder<DesirableSkill> builder)
        {

        }

    }
}
