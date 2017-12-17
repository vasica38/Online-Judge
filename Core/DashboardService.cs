using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Ardalis.GuardClauses;


namespace Core.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IAsyncRepository<UserDashboard> userDashboards;

        public DashboardService(IAsyncRepository<UserDashboard> repository)
        {
            userDashboards = repository;
        }


        public async Task AddSubmissionToDashboardAsync(int submissionId, int userID)
        {
            var dashboard = await userDashboards.GetByIdAsync(userID);

            dashboard.AddSolution(new Entities.Solution(submissionId));

            await userDashboards.UpdateAsync(dashboard);
        }

        //public async int GetSubmissionCount(string userName)
        //{
        //    Guard.Against.NullOrEmpty(userName, nameof(userName));

        //    int count = 0;

        //    return count;
        //}

        Task<int> IDashboardService.GetSubmissionCount(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
