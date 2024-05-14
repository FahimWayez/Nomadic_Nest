using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class UMSContext : DbContext
    {
        public UMSContext() : base("name=UMSContext")
        {
        }
        public DbSet<User> users { get; set; }

        public DbSet<Post> posts { get; set; }

        public DbSet<Service> services { get; set; }

        public DbSet<Comment> comments { get; set; }

        public DbSet<Order> orders { get; set; }

        public DbSet<OrderDetails> ordersDetails { get; set; }

        public DbSet<Token> tokens { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithRequired(od => od.Order)
                .HasForeignKey(od => od.order_Id)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Service>()
                .HasMany(s => s.OrderDetails)
                .WithRequired(od => od.Service)
                .HasForeignKey(od => od.service_id)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
