using Server.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Server.Tools
{
    public class LoadTests
    {
        List<Test> tests = new List<Test>();
        string problemName;



        public List<Test> Get(string path, string problemName)
        {
            if (Directory.Exists(path))
            {
                Process(path, problemName);
                return tests;
            }
            else
            {
                return null;
            }
        }

        private void Process(string path, string problemName)
        {
            string[] files = Directory.GetFiles(path);
            int i = 0;
            foreach(string file in files)
            {
                Test test = new Test();
                Console.WriteLine("loaded test {0} ", file);
                if (Path.GetFileName(file)[0] == 'I' || Path.GetFileName(file)[0] == 'i')
                {
                    test.In = true;
                }
                else
                {
                    test.Out = true;
                }
                string text = System.IO.File.ReadAllText(file);
                test.Data = text;
                test.Id = ++i;
                test.Name = problemName;

                tests.Add(test);
            }
        }
    }
}
