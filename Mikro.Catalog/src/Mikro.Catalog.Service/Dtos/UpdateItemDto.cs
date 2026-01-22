using System.ComponentModel.DataAnnotations;

namespace Mikro.Catalog.Service.Dtos
{
    public record UpdateItemDto
    (
        [Required]
        string Name,
        string Description,
        [Range (0,1000)]
        decimal Price
    );

}
