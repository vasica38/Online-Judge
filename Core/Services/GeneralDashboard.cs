using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class GeneralDashboard : IDashboardService
    {
        public readonly List<Solution> solutions = new List<Solution>();

        public IReadOnlyCollection<Solution> Solutions => solutions.AsReadOnly();

        public void AddSolution(Solution solution)
        {
            solutions.Add(solution);
        }

        public Task AddSubmissionToDashboardAsync(int submissionId, int userID)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetSubmissionCount(string userName)
        {
            throw new NotImplementedException();
        }
    }
}

