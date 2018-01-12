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
            throw new NotImplementedException();
        }
    }
}
