using System;
using Server.Server;
using Server.Tools;
using Server.Models;
using System.Collections.Generic;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            EventQueue events = new EventQueue();
            TcpServer.Queue = events;

            TcpServer.Start();

            /*
            LoadTests loader = new LoadTests();
            List<Test> tests = new List<Test>();
            List<Test> tests1 = new List<Test>();

            tests = loader.Get("B:\\tests\\adunare", "adunare");
            tests1 = loader.Get("B:\\tests\\ciurul", "ciurul");

            GCC gcc = new GCC(@"C:\MinGW\bin\g++.exe");
            CompilerFactory.RegisterCompiler("C++", gcc);


            tests.AddRange(tests1);
            Repository repository = new Repository();
            repository.Tests = tests;


            Judge judge = new Judge("B:\\evaluare", "C++", repository);
            SubmissionJson submission = new SubmissionJson
            {
                Code = "#include <fstream> @ int main() { std::cout << 1 ; return 0; }",
                Language = "C++",
                SubmissionAccountId = "1",
                SubmissionProblemId = 1,
                ProblemName = "adunare",
                Id = 1
                
            };

            submission.Code = submission.Code.Replace("@",  System.Environment.NewLine);


            SaveSolution saveSolution = new SaveSolution(submission.Code, @"B:\solutions", submission.ProblemName + submission.SubmissionAccountId, "cpp");
            saveSolution.SaveFile();

            Dictionary<int, string> submissionsPaths = new Dictionary<int, string>();
            submissionsPaths[submission.Id] = saveSolution.GetCodePath();

            judge.SetSubmissionPath(submissionsPaths);

            judge.Evaluate(submission);




    */
        Console.Read();
           
        }
    }
}
