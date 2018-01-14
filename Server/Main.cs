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
            //EventQueue events = new EventQueue();
            //TcpServer.Queue = events;

            //TcpServer.Start();
            LoadTests loader = new LoadTests();
            List<Test> tests = new List<Test>();
            List<Test> tests1 = new List<Test>();

            tests = loader.Get("B:\\tests\\adunare", "adunare");
            tests1 = loader.Get("B:\\tests\\ciurul", "ciurul");

            for (int i = 0; i < tests1.Count; ++i)
            {
                tests.Add(tests1[i]);
            }

            Repository repository = new Repository();
            repository.Tests = tests;

            Judge judge = new Judge("B:\\evaluare", "GCCCompiler", repository);
            SubmissionJson submission = new SubmissionJson
            {
                Code = "#include <iostream> using namespace std; int main() { cout << 1 ; return 0; }",
                Language = "C++",
                SubmissionAccountId = "1",
                SubmissionProblemId = 1
            };


            judge.Evaluate(submission);


            Console.Read();
           
        }
    }
}
