using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTesting.Models
{
    public class Store
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int countJual { get; set; }
        public virtual ICollection<Act> Acts { get; set; }

        public void delete_data(ActDBContext db){
            db.Stores.Remove(this);
            db.SaveChanges();
        }
    }

}