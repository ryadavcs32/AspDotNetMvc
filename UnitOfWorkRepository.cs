using MyApp.DataAccessLayer.Data;
using MyApp.DataAccessLayer.Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        private readonly ApplicationDbContextcs _context;
        public ICategoryRepository Category{get ; private set;}
        public UnitOfWorkRepository(ApplicationDbContextcs context)
        {
            _context = context;
            Category = new CategoryRepository(context);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
