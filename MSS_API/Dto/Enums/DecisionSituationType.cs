using System.ComponentModel.DataAnnotations;

namespace MSS_API.Dto.Enums
{
    public enum DecisionSituationType : byte
    {
        [Display(Name = "ProceedRequest", Description = "Proceed Request")]
        ProceedRequest = 0,
    }
}
