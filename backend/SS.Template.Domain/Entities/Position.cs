using System;
using System.Collections.Generic;
using SS.Template.Domain.Model;

namespace SS.Template.Domain.Entities
{
    public class Position : Entity, IStatus<EnabledStatus>
    {
        //GENERAL DATA
        public string PositionName { get; set; }

        public string Area { get; set; }

        public string NumberOfRequiredPersonal {  get; set; }

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
        public List<TechnicalKnowledges> TechnicalKnowledge { get; set; }

        //Soft Skills
        public List<SoftSkill> SoftSkills { get; set; }

        //Job Description and Functions
        public List<JobDescriptions> JobDescription { get; set; }

        //Specific Work Experience Requirements
        public List<SpecificWorkExperienceRequirement> WorkExperienceRequirements { get; set; }

        public List<DesirableSkill> DesirableSkills { get; set; }

        public string Notes { get; set; }

        public EnabledStatus Status { get; set; }

    }
}
