using System.ComponentModel.DataAnnotations;

namespace MSS_API.Dto.Enums
{
    public enum ManagementType : byte
    {
        [Display(Name="Admin", Description ="System admin")]
        Admin = 0,

        [Display(Name = "TopLevel", Description = "Top level manager")]
        TopLevel = 1,

        [Display(Name = "MiddleLevel", Description = "Middle level manager")]
        MiddleLevel = 2,

        [Display(Name = "LowLevel", Description = "Low level manager")]
        LowLevel = 3,

        [Display(Name = "Labourer", Description = "Labourer")]
        Labourer = 4,
    }
}
