using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace MSS_API.Models.Factories
{
    public class Factory
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Factory Id")]
        public string Location { get; set; }
    }
}
