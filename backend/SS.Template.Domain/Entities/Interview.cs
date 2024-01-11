using System;
using System.Collections.Generic;
using SS.Template.Domain.Model;

namespace SS.Template.Domain.Entities
{
    public class Interview : Entity, IStatus<EnabledStatus>
    {
        public string Name { get; set; }

        public string CV { get; set; }

        public string Position { get; set; }

        public string PositionLevel { get; set; }

        public DateTime InterviewDate { get; set; }

        public string InterviewTeam { get; set; }

        public string InterviewTeam2 { get; set; }

        public string InterviewLead { get; set; }

        public string CandidateBackground { get; set; }

        public List<TechSkill> TechSkill { get; set; }

        public string DevMethodology { get; set; }

        public int Attitude { get; set; }

        public int Leadership { get; set; }

        public int CriticalThinking { get; set; }

        public int Assertiveness { get; set; }

        public int SelfLearning { get; set; }

        public int Teamwork { get; set; }

        public int Potential { get; set; }

        public int English { get; set; }

        public string PinnacleTitle { get; set; }

        public string Comments { get; set; }

        public string Resolution { get; set; }

        public bool CompletedInterview { get; set; }

        public EnabledStatus Status { get; set; }
    }
}
