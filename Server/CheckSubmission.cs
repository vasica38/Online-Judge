using Server.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class CheckSubmission
    {
        private string workingPath;
        private string outputPath;
        private string workAreaPath;

        private readonly Type flag = typeof(File);


        public CheckSubmission(string path)
        {
            workingPath = path + "\\";
        }

        public CheckSubmission(string workingPath, string outputPath, string workAreaPath) : this(workingPath)
        {
            this.outputPath = outputPath;
            this.workAreaPath = workAreaPath;
            this.workingPath = workingPath + "\\"; 
        }

        public Execution  Execute(string testsPath, ProblemTest test, Problem problem)
        {
            Execution execution;

            try
            {
                CopyTestToWorkArea(testsPath + test.Name + Constants.In, problem);
                ProcessStartInfo psi = new ProcessStartInfo(workingPath + problem.Name + Constants.exe);
                psi.WorkingDirectory = workingPath;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                Process exec = new Process();
                exec.StartInfo = psi;
                bool hasExited = false;
                double totalMilliseconds = 0;

                lock(flag)
                {
                    exec.Start();
                    exec.WaitForExit(problem.TimeLimit + 230);
                    totalMilliseconds = exec.TotalProcessorTime.TotalMilliseconds;

                    if (!(hasExited = exec.HasExited))
                    {
                        exec.CloseMainWindow();
                        exec.Kill();
                    }

                    exec.Dispose();
                    Thread.Sleep(250);
                }


                string outputFilePath = workingPath + problem.Name + Constants.Out;
                execution = new Execution(hasExited, (int)totalMilliseconds, 0, GetOutputString(outputFilePath), File.Exists(outputFilePath));
                DeleteOutputFile(outputFilePath);

            }
            catch (Exception e)
            {
                execution = new Execution(false, 0, 0, e.Message, false);
            }


            return execution;
        }

        public Execution Execute2(string testsPath, ProblemTest test, Problem problem)
        {
            Execution status;
            try
            {
                CopyTestToWorkArea(testsPath + test.Name + Constants.In, problem);
                ProcessStartInfo psi = new ProcessStartInfo(@"b:\tests\adunare\a" + Constants.exe);
                psi.WorkingDirectory = workingPath;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                Process exec = new Process();
                exec.StartInfo = psi;
                bool hasExited = false;
                double totalMilliseconds = 0;
                double memoryUsed = 0;
                lock (flag)
                {
                    exec.Start();
                    var ts = new CancellationTokenSource();
                    Task.Run(() =>
                    {
                        Thread.Sleep(5);
                        try
                        {
                            while (!exec.HasExited)
                            {
                                try
                                {
                                    var m = exec.WorkingSet64 / 1024.0 / 1024.0;
                                    if (m > memoryUsed)
                                    {
                                        memoryUsed = m;
                                    }
                                }
                                catch (Exception e) { var x = e.Message; }
                            }
                        }
                        catch { }
                    }, ts.Token);
                    exec.WaitForExit(problem.TimeLimit + 200);
                    totalMilliseconds = exec.TotalProcessorTime.TotalMilliseconds;
                    if (!(hasExited = exec.HasExited))
                    {
                        exec.CloseMainWindow();
                        exec.Kill();
                    }
                    ts.Cancel();
                    exec.Dispose();
                    Thread.Sleep(250);
                }

                string outputFilePath = workingPath + problem.Name + Constants.Out;
                status = new Execution(hasExited, (int)totalMilliseconds, memoryUsed,  GetOutputString(outputFilePath), File.Exists(outputFilePath));
                DeleteOutputFile(outputFilePath);
            }
            catch (Exception e)
            {
                status = new Execution(false, 0, 0, e.Message , false );
            }
            return status;
        }

        public Execution ExecuteInWorkArea(string testsPath,ProblemTest test, Problem problem)
        {
            Execution status;
            try
            {
                CopyTestToWorkArea(testsPath + test.Name + Constants.In, problem);
                //ProcessStartInfo psi = new ProcessStartInfo(_sandboxStartPath + " " + _workingPath + problem.Name + Constants.exe);
                ProcessStartInfo psi = new ProcessStartInfo(workAreaPath, "/wait /silent /hide_window " + workingPath + problem.Name + Constants.exe);
                psi.WorkingDirectory = workingPath;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                Process exec = new Process();
                exec.StartInfo = psi;
                bool hasExited = false;
                double totalMilliseconds = 0;
                lock (flag)
                {
                    exec.Start();
                    exec.WaitForExit(problem.TimeLimit + 1000);
                    totalMilliseconds = exec.TotalProcessorTime.TotalMilliseconds;
                    if (!(hasExited = exec.HasExited))
                    {
                        exec.CloseMainWindow();
                        exec.Kill();
                    }
                    exec.Dispose();
                    Process.Start(workAreaPath, "/terminate_all");
                    Thread.Sleep(250);
                }
                string outputFilePath = outputPath + problem.Name + Constants.Out;
                status = new Execution(hasExited, (int)totalMilliseconds, 0, GetOutputString(outputFilePath), File.Exists(outputFilePath));
                DeleteOutputFile(outputFilePath);
            }
            catch (Exception e)
            {
                status = new Execution(false, 0, 0, e.Message, false);
            }
            return status;
        }


        private void DeleteOutputFile(string outputFilePath)
        {
            try
            {
                lock (flag)
                {
                    File.Delete(outputFilePath);
                }
            }
            catch (Exception)
            {
            }
        }

        private string GetOutputString(string path)
        {
            try
            {
                lock (flag)
                {
                    return File.Exists(path) ? File.ReadAllText(path) : String.Empty;
                }
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }

        private void CopyTestToWorkArea(string v, Problem problem)
        {
            try
            {
                lock (flag)
                {
                    File.Copy(v, workingPath + problem.Name + Constants.In, true);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
