using IMS.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IMS.Data
{
    public class IMSContext : DbContext
    {
        public IMSContext(DbContextOptions<IMSContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
