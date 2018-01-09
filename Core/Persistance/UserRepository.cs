using Core.Interfaces;
using Core.Model;

namespace Core.Persistance
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataBaseContext db) : base(db)
        {

        }

        public User GetUserWithSolution(int id)
        {
            return null;
          //  return DataBaseContext.Users.Include(a => a.Solutions).SingleOrDefault(a => a.Id==id);
        }

        User IUserRepository.GetUserWithSolution(int id)
        {
            throw new System.NotImplementedException();
        }

        User IRepository<User>.Get(int id)
        {
            throw new System.NotImplementedException();
        }

        System.Collections.Generic.IEnumerable<User> IRepository<User>.GetAll()
        {
            throw new System.NotImplementedException();
        }

        public System.Collections.Generic.IEnumerable<User> Find(System.Linq.Expressions.Expression<System.Func<User, bool>> predicate)
        {
            throw new System.NotImplementedException();
        }

        public User SingleOrDefault(System.Linq.Expressions.Expression<System.Func<User, bool>> predicate)
        {
            throw new System.NotImplementedException();
        }

        public void Add(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void AddRange(System.Collections.Generic.IEnumerable<User> entities)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveRange(System.Collections.Generic.IEnumerable<User> entities)
        {
            throw new System.NotImplementedException();
        }

        public DataBaseContext DataBaseContext
        {
            get
            {
                return Context as DataBaseContext;
            }
        }

    }
}
