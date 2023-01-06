using MSS_API.Dto.Enums;
using System.ComponentModel.DataAnnotations;

namespace MSS_API.Models.Decisions
{
    public class ManagementDecisions
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "KPI")]
        public long Decision { get; set; }

        [Display(Name = "Management Type")]
        public ManagementType ManagementType { get; set; }

        [Display(Name = "Situation Type")]
        public DecisionSituationType SituationType { get; set; }
    }
}
