using s198599_mappe3.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace s198599_mappe3.Models.Repository
{
    public class CategoryRepo : IFaqDb<Category>
    {
        DataContext context = new DataContext();

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool edit(Category obj)
        {
            throw new NotImplementedException();
        }

        public Category get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> getList()
        {
            return context.Category.Select(q => 
            new Category {
                CategoryID = q.CategoryID,
                CategoryName = q.CategoryName }).ToList();
        }

        public bool save(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}