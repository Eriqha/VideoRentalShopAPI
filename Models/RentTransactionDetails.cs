namespace VideoRentalShopAPI.Models
{
    public class RentalDetail
{
        public int RentalDetailId { get; set; }
        public int TransactionId { get; set; }
        public RentalHeader Transaction { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
