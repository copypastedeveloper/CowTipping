using System;
using System.Data.Entity;

namespace CowTippingService
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("CowTipping")
        {}

        public DbSet<TippedCow> TippedCows { get; set; }
    }

    public class TippedCow
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime DateTipped { get; set; }
    }
}