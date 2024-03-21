using System.ComponentModel.DataAnnotations;

namespace TheWaterProject.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProgramName { get; set; }
        public string ProjectType { get; set; }
        public string ProjectImpact { get; set; }
        public DateTime ProjectInstallationDate { get; set; }
        public string ProjectPhase { get; set; }
    }
}
