using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ProjectContext _projectContext;
        public CategoryRepository(ProjectContext projectContext) : base (projectContext)
        {
            _projectContext = projectContext;
        }
        public void save()
        {
            _projectContext.SaveChanges();
        }

        public void update(Category obj)
        {
            
            _projectContext.Update(obj);
        }
    }
}
