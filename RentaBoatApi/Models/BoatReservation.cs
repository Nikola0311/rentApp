using System;
using System.Collections.Generic;

namespace RentaBoatApi.Models
{
    public partial class BoatReservation
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public int? PersonsNumber { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public int IdBoat { get; set; }

       public virtual Boat IdBoatNavigation { get; set; } = null!;
    }
}
