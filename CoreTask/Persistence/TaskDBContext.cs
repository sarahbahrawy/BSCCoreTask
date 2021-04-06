using CoreTask.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTask.Persistence
{
    public class TaskDBContext: DbContext
    {
        public TaskDBContext(DbContextOptions<TaskDBContext> options)
              : base(options)
        {

        }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Visits> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskDBContext).Assembly);

            modelBuilder.Entity<Visits>().HasOne(x => x.sales).WithMany(x => x.visits).HasForeignKey(x => x.SalesID).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Visits>().HasOne(x => x.customer).WithMany(x => x.visits).HasForeignKey(x => x.CustomerID).OnDelete(DeleteBehavior.SetNull);

        }
    }
}
