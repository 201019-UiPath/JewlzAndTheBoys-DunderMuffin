
namespace DMDB.Models
{
    public class InventoryItem
    {
        public int locationId { get; set; }

        public int productId { get; set; }

        public int quantityOnHand { get; set; }

        public Location Location { get; set; }

        public Product Product { get; set; }
    }
}