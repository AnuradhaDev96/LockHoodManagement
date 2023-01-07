using System.ComponentModel.DataAnnotations;

namespace MSS_API.Dto.Enums
{
    public enum KanBanStatus : byte
    {
        [Display(Name = "New", Description = "Task is just created")]
        New = 0,

        [Display(Name = "In Progress", Description = "Task is in progress")]
        InProgress = 1,

        [Display(Name = "On Hold", Description = "Task is on hold due to remaining items")]
        OnHold = 2,

        [Display(Name = "Completed", Description = "Task is completeds")]
        Completed = 3,
    }
}
