using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Interfaces
{
    public interface IVerifier
    {
        SubmissionResult Verify(Submission submission, Problem problem, ProblemTest problemTest, Execution execution, string output);
    }
}
