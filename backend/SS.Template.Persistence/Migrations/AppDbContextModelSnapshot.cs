// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SS.Template.Persistence;

#nullable disable

namespace SS.Template.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SS.Template.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("OrderTotal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0m);

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Status");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.DesirableSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("Status");

                    b.ToTable("DesirableSkill");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.Example", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("NormalizedName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique();

                    b.HasIndex("Status");

                    b.ToTable("Example");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.Interview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Assertiveness")
                        .HasColumnType("integer");

                    b.Property<int>("Attitude")
                        .HasColumnType("integer");

                    b.Property<string>("CV")
                        .HasColumnType("text");

                    b.Property<string>("CandidateBackground")
                        .HasColumnType("text");

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<bool>("CompletedInterview")
                        .HasColumnType("boolean");

                    b.Property<int>("CriticalThinking")
                        .HasColumnType("integer");

                    b.Property<string>("DevMethodology")
                        .HasColumnType("text");

                    b.Property<int>("English")
                        .HasColumnType("integer");

                    b.Property<DateTime>("InterviewDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InterviewLead")
                        .HasColumnType("text");

                    b.Property<string>("InterviewTeam")
                        .HasColumnType("text");

                    b.Property<string>("InterviewTeam2")
                        .HasColumnType("text");

                    b.Property<int>("Leadership")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PinnacleTitle")
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .HasColumnType("text");

                    b.Property<string>("PositionLevel")
                        .HasColumnType("text");

                    b.Property<int>("Potential")
                        .HasColumnType("integer");

                    b.Property<string>("Resolution")
                        .HasColumnType("text");

                    b.Property<int>("SelfLearning")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Teamwork")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Status");

                    b.ToTable("Interview");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.Interviewers", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ActiveInterviewer")
                        .HasColumnType("integer");

                    b.Property<string>("BambooStatus")
                        .HasColumnType("text");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Department")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("Division")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("JobTitle")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Status");

                    b.ToTable("Interviewers");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.JobDescriptions", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("Status");

                    b.ToTable("JobDescriptions");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Age")
                        .HasColumnType("text");

                    b.Property<string>("Area")
                        .HasColumnType("text");

                    b.Property<string>("Degree")
                        .HasColumnType("text");

                    b.Property<string>("DegreeLevel")
                        .HasColumnType("text");

                    b.Property<string>("EnglishLevel")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("JobObjective")
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .HasColumnType("text");

                    b.Property<string>("NumberOfRequiredPersonal")
                        .HasColumnType("text");

                    b.Property<string>("PositionName")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("RequestDate")
                        .HasColumnType("date");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("StatusDegree")
                        .HasColumnType("text");

                    b.Property<string>("YearsOfExperience")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Status");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.SoftSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("Status");

                    b.ToTable("SoftSkill");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.SpecificWorkExperienceRequirement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("Status");

                    b.ToTable("SpecificWorkExperienceRequirement");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.TechSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("InterviewId")
                        .HasColumnType("uuid");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Skill")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InterviewId");

                    b.HasIndex("Status");

                    b.ToTable("TechSkill");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.TechnicalKnowledges", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("Status");

                    b.ToTable("TechnicalKnowledges");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.DesirableSkill", b =>
                {
                    b.HasOne("SS.Template.Domain.Entities.Position", null)
                        .WithMany("DesirableSkills")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.JobDescriptions", b =>
                {
                    b.HasOne("SS.Template.Domain.Entities.Position", null)
                        .WithMany("JobDescription")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.SoftSkill", b =>
                {
                    b.HasOne("SS.Template.Domain.Entities.Position", null)
                        .WithMany("SoftSkills")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.SpecificWorkExperienceRequirement", b =>
                {
                    b.HasOne("SS.Template.Domain.Entities.Position", null)
                        .WithMany("WorkExperienceRequirements")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.TechSkill", b =>
                {
                    b.HasOne("SS.Template.Domain.Entities.Interview", null)
                        .WithMany("TechSkill")
                        .HasForeignKey("InterviewId");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.TechnicalKnowledges", b =>
                {
                    b.HasOne("SS.Template.Domain.Entities.Position", null)
                        .WithMany("TechnicalKnowledge")
                        .HasForeignKey("PositionId");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.Interview", b =>
                {
                    b.Navigation("TechSkill");
                });

            modelBuilder.Entity("SS.Template.Domain.Entities.Position", b =>
                {
                    b.Navigation("DesirableSkills");

                    b.Navigation("JobDescription");

                    b.Navigation("SoftSkills");

                    b.Navigation("TechnicalKnowledge");

                    b.Navigation("WorkExperienceRequirements");
                });
#pragma warning restore 612, 618
        }
    }
}
