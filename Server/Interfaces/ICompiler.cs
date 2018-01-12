using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Interfaces
{
    public interface ICompiler
    {
        bool Compile(string sourcePath, out string executablePath);
    }
}
