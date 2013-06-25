using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcTesting.Models;
using System.ComponentModel.DataAnnotations;

namespace MvcTesting.Models
{
    public class Act
    {
        public int Id { get; set; }
        public string Title { get; set; }      
        public string Address { get; set; }
        public int JenisKelamin{get; set;}        
        public int MovieID { get; set; }
        public Movie Movies { get; set; }
        public int StoreID { get; set; }
        public Store[] Stores { get; set; }
    }   
    
}