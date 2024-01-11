using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SS.Template.Core;
using SS.Template.Domain.Entities;

namespace SS.Template.Persistence.Configurations
{
    
    public sealed class InterviewersConfiguration : IEntityTypeConfiguration<Interviewers>
    {
        public void Configure(EntityTypeBuilder<Interviewers> builder)
        {
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(AppConstants.StandardValueLength);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(AppConstants.StandardValueLength);

            builder.Property(x => x.Email)
                .IsRequired();

        }
    }
}
