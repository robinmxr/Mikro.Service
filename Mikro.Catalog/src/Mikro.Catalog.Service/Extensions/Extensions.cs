using Mikro.Catalog.Service.Dtos;
using Mikro.Catalog.Service.Entities;

namespace Mikro.Catalog.Service.Extensions
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }
    }
}
