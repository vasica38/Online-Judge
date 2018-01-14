using Server.Models;
using System;

namespace Server
{
    public class EvaluationResultEventArgs : EventArgs
    {
 //       public Contestant Contestant { get; private set; }
        public Problem Problem { get; private set; }
        public ProblemTest Test { get; private set; }
        public SubmissionResult Result { get; private set; }
        public Status Status { get; private set; }

        public EvaluationResultEventArgs(Problem problem, ProblemTest test, SubmissionResult result, Status status)
        {
            Problem = problem;
            Test = test;
            Result = result;
            Status = status;
        }

        public EvaluationResultEventArgs()
        {
        }
    }
}