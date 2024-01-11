using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.Template.Application.Features.DesirableSkills;
using SS.Template.Application.Features.JobDescription;
using SS.Template.Application.Features.SoftSkills;
using SS.Template.Application.Features.SpecificWorkExperienceRequirements;
using SS.Template.Application.Features.TechnicalKnowledge;
using SS.Template.Domain.Entities;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.Positions
{
    public class PositionsModel : IStatus<EnabledStatus>
    {
        public Guid Id { get; set; }

        //GENERAL DATA
        public string PositionName { get; set; }

        public string Area { get; set; }

        public string NumberOfRequiredPersonal { get; set; }

        public string YearsOfExperience { get; set; }

        public DateOnly? RequestDate { get; set; }

        public string Location { get; set; }

        //PERSONAL ASPECTS
        public string Gender { get; set; }

        public string Age { get; set; }

        //EDUCATION REQUIREMENTS
        public string DegreeLevel { get; set; }

        public string StatusDegree { get; set; }

        public string Degree { get; set; }

        public string EnglishLevel { get; set; }

        //JobObjective
        public string JobObjective { get; set; }

        //Technical Knowledge
        public List<TechnicalKnowledgeModel> TechnicalKnowledge { get; set; }

        //Soft Skills
        public List<SoftSkillsModel> SoftSkills { get; set; }

        //Job Description and Functions
        public List<JobDescriptionModel> JobDescription { get; set; } 

        //Specific Work Experience Requirements
        public List<SpecificWorkExperiencerequirementsModel> WorkExperienceRequirements { get; set; }

        public List<DesirableSkillsModel> DesirableSkills { get; set; }

        public string Notes { get; set; }

        public EnabledStatus Status { get; set; }
    }
}
