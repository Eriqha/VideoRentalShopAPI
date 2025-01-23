namespace VideoRentalShopAPI.Models
{
    public class RentalHeader
    {
        public int RentalHeaderId { get; set; }
        public int CustomerId { get; set; }
        public ICollection<RentalDetail> RentalDetails { get; set; }
    }
}
