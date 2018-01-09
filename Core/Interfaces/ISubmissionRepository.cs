using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISubmissionRepository: IRepository<Solution> 
    {
        Solution GetSolutionWithUser(int id);
    }
}
