using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Server.Models
{
    public class GCC : ICompiler
    {
        private string path;

        public bool Compile(string sourcePath, out string executablePath)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            string[] parts = sourcePath.Split('.');

            if (parts.Length > 2)
            {
                for(int i = 1; i < parts.Length -1; ++i)
                {
                    parts[0] += "." + parts[i];
                }
            }

            psi.FileName = path;
            psi.Arguments = "-o " + parts[0] + " " + sourcePath;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            var p = Process.Start(psi);
            p.WaitForExit(3459);

            if (!p.HasExited)
            {
                p.Kill();
            }

            executablePath = sourcePath.Remove(sourcePath.LastIndexOf('.')) + ".exe";
            return File.Exists(executablePath);
        }

        public GCC(string cstrPath)
        {
            path = cstrPath;
        }
    }
}
