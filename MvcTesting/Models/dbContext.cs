using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcTesting.Models
{
    public class ActDBContext : DbContext
    {
        public DbSet<Act> Acts { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Store> Stores { get; set; }        
    }
    
}