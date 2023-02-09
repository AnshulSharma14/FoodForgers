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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        
        public void Update(Category category)
        {
            _context.Update(category);
        }

        private readonly ApplicationDbContext _context;
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
 
}
}
