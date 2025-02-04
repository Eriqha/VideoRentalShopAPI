using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace VideoRentalShopAPI.Models
{
    public class RentalHeader
    {
        public int? RentalHeaderId { get; set; }
        public int CustomerId { get; set; }
        public required string MovieName { get; set; }
        public Customer Customer{ get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public ICollection<RentalDetail>? RentalDetails { get; set; }
    }
}
