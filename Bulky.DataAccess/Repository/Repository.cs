using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ProjectContext _projectContext;
        private readonly DbSet<T> _dbSet;
        public Repository(ProjectContext projectContext)
        {

            _projectContext = projectContext;
            this._dbSet = _projectContext.Set<T>();

        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public T Get(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet.Where(predicate);
            //IQueryable<T> query = _dbSet;
            //query = query.Where(predicate);
            return   query.FirstOrDefault();
        }
        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T entity)
        {
            _dbSet.AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public IQueryable<T> Getting(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

    }
}
