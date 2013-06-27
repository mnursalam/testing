using System;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace MvcTesting.Models
{
    public class BusinessLogic : ActDBContext
    {
        public PagedList.IPagedList getPaginateListMovies(int? page = 1)
        {
            int pageSize = 2;
            int pageNumber = (page ?? 1);
            var list = this.Movies.ToList();
            return list.ToPagedList(pageNumber, pageSize);
        }

        public void update_data(Object obj)
        {
            this.Entry(obj).State = EntityState.Modified;
            this.SaveChanges();
        }
        

    }
}