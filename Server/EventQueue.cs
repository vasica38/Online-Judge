using Server.Interfaces;
using Server.Models;
using Server.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class EventQueue
    {
        private Queue<SubmissionEvent> events = new Queue<SubmissionEvent>();

        public void Add(SubmissionEvent _event)
        {
            events.Enqueue(_event);
            EventLoop();
        }

        public void EventLoop()
        {
            while(events.Count>0)
            {


                LoadTests loader = new LoadTests();
                List<Test> tests = new List<Test>();
                List<Test> tests1 = new List<Test>();

                tests = loader.Get("B:\\tests\\adunare", "adunare");
                tests1 = loader.Get("B:\\tests\\ciurul", "ciurul");

                GCC gcc = new GCC(@"C:\MinGW\bin\g++.exe");
                CompilerFactory.RegisterCompiler("C++", gcc);
                CompilerFactory.RegisterCompiler("C++11", gcc);
                CompilerFactory.RegisterCompiler("C+11", gcc);

                CompilerFactory.RegisterCompiler("C++14", gcc);
                CompilerFactory.RegisterCompiler("C", gcc);




                tests.AddRange(tests1);
                Repository repository = new Repository();
                repository.Tests = tests;


                Judge judge = new Judge("B:\\evaluare", "C++", repository);
                SubmissionJson submission = events.Dequeue().Submission;

                submission.Code = submission.Code.Replace("@", System.Environment.NewLine);


                SaveSolution saveSolution = new SaveSolution(submission.Code, @"B:\solutions", submission.ProblemName + submission.SubmissionAccountId, "cpp");
                saveSolution.SaveFile();

                Dictionary<int, string> submissionsPaths = new Dictionary<int, string>();
                submissionsPaths[submission.Id] = saveSolution.GetCodePath();

                judge.SetSubmissionPath(submissionsPaths);

                judge.Evaluate(submission);

            }
        }
    }
}
