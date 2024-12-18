using API.Model;

namespace API.Dto
{
    public class ItemRequest
    {
        
        public required string Name { get; set; } = null!;

        public required int Price { get; set; }

        public required int ItemCount { get; set; }

        public required int CategoryId { get; set; }
    }
}
