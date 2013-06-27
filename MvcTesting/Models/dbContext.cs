using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace MvcTesting.Models
{
    public class ActDBContext : DbContext        
    {
        //public static string ConnectionString { get; set; }
        //public ActDBContext() : base(ConnectionString ?? "dbconn1")
        public ActDBContext() : base("dbconn1")
        {
        }
        public DbSet<Act> Acts { get; set; } 
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Store> Stores { get; set; }        
    }
    
}