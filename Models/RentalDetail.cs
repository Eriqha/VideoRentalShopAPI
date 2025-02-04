namespace VideoRentalShopAPI.Models
{
    public class RentalDetail
    {
        public int RentalDetailId { get; set; }
        public int RentalHeaderId { get; set; }
        public int MovieId { get; set; }

        public RentalHeader? RentalHeaders { get; set; }
        public Movie? Movies { get; set; }


        }
    } 