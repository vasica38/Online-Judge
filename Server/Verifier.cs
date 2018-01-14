using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public class Verifier : IVerifier
    {
        public SubmissionResult Verify(Submission submission, Problem problem, ProblemTest problemTest, Execution execution, string output)
        {
            SubmissionResult submissionResult = new SubmissionResult
            {
                SubmissionId = submission.Id,
                TestId = submission.Id,
                Time = execution.TotalMs,
                Memory = (int)execution.UsedMemoryKBs
            };

            if (problem.TimeLimit + 199 < execution.TotalMs)
            {
                submissionResult.Score = 0;
                submissionResult.StatusId = StatusFactory.GetStatus(Constants.Statuses.Codes.TLE).Id;
            }
            if (problem.MemoryLimit < execution.UsedMemoryKBs)
            {
                submissionResult.Score = 0;
                submissionResult.StatusId = StatusFactory.GetStatus(Constants.Statuses.Codes.MLE).Id;
            }
            else if (!execution.HasOutputFile)
            {
                submissionResult.Score = 0;
                submissionResult.StatusId = StatusFactory.GetStatus(Constants.Statuses.Codes.MOF).Id;
            }
            else if (MathcesOutput(output, execution.Output))
            {
                submissionResult.Score = problemTest.Score;
                submissionResult.StatusId = StatusFactory.GetStatus(Constants.Statuses.Codes.OK).Id;
            }
            else
            {
                submissionResult.Score = 0;
                submissionResult.StatusId = StatusFactory.GetStatus(Constants.Statuses.Codes.WA).Id;
            }
            if (!execution.HasTerminated && submissionResult.Score == 0)
            {
                submissionResult.Score = 0;
                submissionResult.StatusId = StatusFactory.GetStatus(Constants.Statuses.Codes.TLE).Id;
            }
            return submissionResult;


            return null;
        }

        private bool MathcesOutput(string output1, string output2)
        {
            output2 = output2.Replace(" ", "");
            output2 = output2.Replace("\t", "");
            output2 = output2.Replace("\n", "");
            output2 = output2.Replace("\r", "");
            output1 = output1.Replace(" ", "");
            output1 = output1.Replace("\t", "");
            output1 = output1.Replace("\n", "");
            output1 = output1.Replace("\r", "");
            return output1 == output2;
        }
    }
}
