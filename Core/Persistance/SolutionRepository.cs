using Core.Model;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance
{
    public class SolutionRepository : Repository<Solution>, ISubmissionRepository
    {
        public void Add(Solution entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Solution> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Solution> Find(System.Linq.Expressions.Expression<Func<Solution, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Solution GetSolutionWithUser(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Solution entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Solution> entities)
        {
            throw new NotImplementedException();
        }

        public Solution SingleOrDefault(System.Linq.Expressions.Expression<Func<Solution, bool>> predicate)
        {
            throw new NotImplementedException();
        }


    }
}
