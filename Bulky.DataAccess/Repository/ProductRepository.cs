using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private readonly ProjectContext _context;

        public ProductRepository(ProjectContext projectContext) : base(projectContext)
        {
                _context = projectContext;
        }
        public void update(Product obj)
        {
            _context.Update(obj);
        }
    }
}
