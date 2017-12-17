using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDashboardService
    {
        Task<int> GetSubmissionCount(string userName);
        Task AddSubmissionToDashboardAsync(int submissionId, int userID);
    }
}
