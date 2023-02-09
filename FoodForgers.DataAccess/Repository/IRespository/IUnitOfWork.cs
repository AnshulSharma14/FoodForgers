using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForgers.DataAccess.Repository.IRespository
{
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        void save();
        
    }
}
