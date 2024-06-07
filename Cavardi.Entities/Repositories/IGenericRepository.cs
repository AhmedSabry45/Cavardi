using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cavardi.Entities.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        //_Context.Categories.ToList();
        //_Context.Categories.Include("Products").ToList();
        //_Context.Categories.Where(x=>x.Id==id).ToList();
        IEnumerable<T> GetAll(Expression<Func<T,bool>>?predicate=null,string ? Includeword = null);

        //_Context.Categories.Include("Products").SingleOrdefault();
        //_Context.Categories.Where(x=>x.Id==id).SingleOrdefault();
        T GetFirstOrDefault(Expression<Func<T, bool>> ?predicate=null, string? Includeword=null);

        //_Context.Categories.Add(category);

        void Add(T entity);

        //_Context.Categories.Remove(category);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
       

    }
}
