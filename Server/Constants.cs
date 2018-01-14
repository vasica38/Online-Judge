using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Constants
    {
        public static readonly string Evaluator = "Evaluator";
        public static readonly string EvaluationPath = "EvaluationPath";
        public static readonly string ApiUrl = "ApiUrl";
        public static readonly string ApiKey = "ApiKey";
        public static readonly string PascalCompiler = "PascalCompiler";
        public static readonly string GPPCompiler = "GPPCompiler";
        public static readonly string SourceFiles = "SourceFiles";
        public static readonly string TestFiles = "TestFiles";
        public static readonly string Contact = "Made by Pojoga Vasile,\nStudent at Faculty of Computer Science,\nUniversity Alexandru Ioan Cuza, Iasi\n" + DateTime.Now;
        public static readonly string HowToUse = "1-Go to settings and select compilers and evaluation paths and API Url\n2-Start the evaluation!";
        public static readonly string CaptionError = "Error";
        public static readonly string ErrorSettings = "Incorrect settings";
        public static readonly string Problems = "Problems";
        public static readonly string Results = "Results";
        public static readonly string pas = ".pas";
        public static readonly string cpp = ".cpp";
        public static readonly string c = ".c";
        public static readonly string exe = ".exe";
        public static readonly string In = ".in";
        public static readonly string Out = ".out";
        public static readonly string Ok = ".ok";
        public static readonly string MissingOutputFile = "Missing output file!";
        public static readonly string WrongAnswer = "Wrong Answer!";
        public static readonly string TLE = "Time Limit Exceded!";
        public static readonly string OK = "OK!";
        public static readonly string PDF = ".pdf";
        public static readonly string GCC = "GCC";
        public static readonly string FPC = "FPC";
        public static readonly string SandboxTempPath = "SandboxTempPath";
        public static readonly string SandboxStartPath = "SandboxStartPath";

        public class Statuses
        {
            public class Codes
            {
                public static readonly string OK = "OK";
                public static readonly string TLE = "TLE";
                public static readonly string MLE = "MLE";
                public static readonly string MOF = "MOF";
                public static readonly string EXE = "EXE";
                public static readonly string WA = "WA";
                public static readonly string COM = "COM";
                public static readonly string DNC = "DNC";
                public static readonly string KILL = "KILL";
                public static readonly string PC = "PC";
            }

            public class Messages
            {
                public static readonly string OK = "OK";
                public static readonly string TLE = "Time Limit Excedeed";
                public static readonly string MLE = "Memory Limit Excedeed";
                public static readonly string MOF = "Missing Ooutput File";
                public static readonly string EXE = "Executed";
                public static readonly string WA = "Wrong Answer";
                public static readonly string COM = "Compiled";
                public static readonly string DNC = "Did Not Compile";
                public static readonly string KILL = "Killed";
                public static readonly string PC = "Plagiarized Code";
            }
        }

        public class Notifications
        {
            public static readonly string Syncronizing = "Syncronizing...";
            public static readonly string GetContestsStarted = "Syncronizing Contests...";
            public static readonly string GetContestsEnded = "Contests Syncronized...";
            public static readonly string GetProblemsStarted = "Syncronizing Problems...";
            public static readonly string GetProblemsEnded = "Problems Syncronized...";
            public static readonly string GetContestantsStarted = "Syncronizing Contestants...";
            public static readonly string GetContestantsEnded = "Contestants Syncronized...";
            public static readonly string GetSubmissionsStarted = "Syncronizing Submissions...";
            public static readonly string GetSubmissionsEnded = "Submissions Syncronized...";
            public static readonly string GetStatusesStarted = "Syncronizing Statuses...";
            public static readonly string GetStatusesEnded = "Statuses Syncronized...";
            public static readonly string GetTestsStarted = "Syncronizing Tests...";
            public static readonly string GetTestsEnded = "Tests Syncronized...";
            public static readonly string GetSubmissionsFilesStarted = "Syncronizing Solutions Files...";
            public static readonly string GetSubmissionsFilesEnded = "Solutions Files Syncronized...";
            public static readonly string GetTestsFilesStarted = "Syncronizing Tests Files...";
            public static readonly string GetTestsFilesEnded = "Tests Files Syncronized...";
            public static readonly string GetSandboxStarted = "Creating Sandbox...";
            public static readonly string GetSandboxEnded = "Sandbox Created...";
            public static readonly string RegisterStatusesStarted = "Registering Statuses...";
            public static readonly string RegisterStatusesEnded = "Statuses Registered...";
            public static readonly string EvaluationBegin = "Evaluation Began...";
            public static readonly string EvaluationEnded = "Evaluation Ended...";
            public static readonly string UpdateRestulStarted = "Updating Results Began...";
            public static readonly string UpdateResultsEnded = "Updating Results Ended...";
        }
    }
}
