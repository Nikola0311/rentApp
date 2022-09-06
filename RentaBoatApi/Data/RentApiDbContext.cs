using Microsoft.EntityFrameworkCore;
using RentaBoatApi.Models;

namespace RentaBoatApi.Data
{
    public class RentApiDbContext : DbContext
    {

        public RentApiDbContext(DbContextOptions opt) : base(opt)
        {

        }

        public DbSet<Boat> Boats { get; set; }
        public DbSet<BoatReservationsModel> BoatReservations { get; set; }

        public DbSet<BoatReservation> BoatRes{ get; set; }

    }
}
