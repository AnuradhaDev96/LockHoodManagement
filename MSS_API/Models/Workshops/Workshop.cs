using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;


namespace MSS_API.Models.Workshops
{
    public class Workshop
    {
        [Key]
        [Display(Name = "Id")]
        [SwaggerSchema(Description = "Identity value of the workshop")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [SwaggerSchema(Description = "Name of workshop")]
        public string Name { get; set; }

        [Display(Name = "Factory Id")]
        [SwaggerSchema(Description = "Factory that workshop belongs to")]
        public int FactoryId { get; set; }
    }
}
