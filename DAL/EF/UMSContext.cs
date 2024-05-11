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
        public DbSet<User> users { get; set; }

        public DbSet<Post> posts { get; set; }  

        public DbSet<Service> services { get; set; }

        public DbSet<Comment> comments { get; set; }

        public DbSet<Order> orders { get; set; }

        public DbSet<Token> tokens { get; set; }
    }
}
