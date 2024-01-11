using System;
using System.Collections.Generic;
using SS.Template.Application.Features.DesirableSkills.Commands;
using SS.Template.Application.Features.JobDescription.Commands;
using SS.Template.Application.Features.SoftSkills.Commands;
using SS.Template.Application.Features.SpecificWorkExperienceRequirements.Commands;
using SS.Template.Application.Features.TechnicalKnowledge.Commands;
using SS.Template.Domain.Model;

namespace SS.Template.Application.Features.Positions.Commands
{
    public class AddPositionsModel : IStatus<EnabledStatus>
    {
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
        public List<AddTechnicalKnowledgeModel> TechnicalKnowledge { get; set; }


        //Soft Skills
        public List<AddSoftSkillsModel> SoftSkills { get; set; }

        //Job Description and Functions
        public List<AddJobDescriptionModel> JobDescription { get; set; }

        //Specific Work Experience Requirements
        public List<AddSpecificWorkExperienceRequirementsModel> WorkExperienceRequirements { get; set; }

        public List<AddDesirableSkillsModel> DesirableSkills { get; set; }

        public string Notes { get; set; }

        public EnabledStatus Status { get; set; }
    }
}
