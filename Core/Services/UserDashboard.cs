using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class UserDashboard: BaseEntity
    {
        public string UserId { get; set; }
        private readonly List<Solution> solutions = new List<Solution>();

        public IReadOnlyCollection<Solution> Solutions => solutions.AsReadOnly();

        public UserDashboard()
        {

        }

        public void AddSolution(Solution solution)
        {
            solutions.Add(solution);
        }
    }
}
