using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class CategoryRepository : Repository<CategoryModel>, ICategoryRepository
    {

        private readonly ApplicationDbContextcs _context;
        public CategoryRepository(ApplicationDbContextcs context) : base(context)
        {
            _context = context; 
        }
       

        public void Update(CategoryModel category)
        {
            _context.Categories.Update(category);
        }
    }
}
