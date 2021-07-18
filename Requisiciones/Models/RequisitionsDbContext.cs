using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Requisiciones.Models
{
    public class RequisitionsDbContext : DbContext
    {
        public RequisitionsDbContext(DbContextOptions<RequisitionsDbContext> options)
            : base(options) { }

        //Define DataSets
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Positions> Positions { get; set; }
        public DbSet<Requisitions> Requisitions { get; set; }
        public DbSet<RequisitionsLogs> RequisitionsLogs { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
