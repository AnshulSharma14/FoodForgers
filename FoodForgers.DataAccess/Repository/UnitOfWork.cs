using FoodForgers.DataAccess.Data;
using FoodForgers.DataAccess.Repository.IRespository;
using FoodForgers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForgers.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        { 
            _context = context;
            CategoryRepository = new CategoryRepository(_context);
        }
        public ICategoryRepository CategoryRepository { get; private set; }

        public void save()
        {
            _context.SaveChanges();
        }
    }
}
