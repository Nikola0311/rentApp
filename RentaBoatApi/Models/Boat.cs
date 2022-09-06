using System;
using System.Collections.Generic;

namespace RentaBoatApi.Models
{
    public partial class Boat
    {
        public Boat()
        {
            BoatReservations = new HashSet<BoatReservation>();
        }

        public int Id { get; set; }
        public string? Producer { get; set; }
        public string? Model { get; set; }
        public int? PersonsMax { get; set; }
        public int? ProductionYear { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<BoatReservation> BoatReservations { get; set; }
    }
}
