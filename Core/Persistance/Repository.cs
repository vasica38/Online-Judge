using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;


namespace Core.Persistance
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly DbContext Context;

        public Repository()
        {
        }

        public Repository(DbContext con)
        {
            Context = con;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);

            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);

            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            var repository = obj as Repository<T>;
            return repository != null &&
                   EqualityComparer<DbContext>.Default.Equals(Context, repository.Context);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return -59922564 + EqualityComparer<DbContext>.Default.GetHashCode(Context);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);

            throw new NotImplementedException();
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().SingleOrDefault(predicate);
            throw new NotImplementedException();
        }
    }
}
