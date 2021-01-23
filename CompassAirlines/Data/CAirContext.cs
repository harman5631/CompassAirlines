using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CompassAirlines.Models;

namespace CompassAirlines.Data
{
    public class CAirContext : DbContext
    {
        public CAirContext (DbContextOptions<CAirContext> options)
            : base(options)
        {
        }

        public DbSet<CompassAirlines.Models.Staff> Staff { get; set; }

        public DbSet<CompassAirlines.Models.Planes> Planes { get; set; }

        public DbSet<CompassAirlines.Models.Flights> Flights { get; set; }
    }
}
