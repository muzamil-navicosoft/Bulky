using Bulky.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        private readonly ProjectContext _projectContext;
        public UnitOfWork(ProjectContext projectContext)
        {
            _projectContext = projectContext;    
            Category = new CategoryRepository(projectContext);
            Product = new ProductRepository(projectContext);
        }

        public void save()
        {
            _projectContext.SaveChanges();
        }
    }
}
