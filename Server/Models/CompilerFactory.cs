using Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public class CompilerFactory
    {
        private static Dictionary<string, ICompiler> compilers = new Dictionary<string, ICompiler>();

        public static void RegisterCompiler(string compilerName, ICompiler compiler)
        {
            compilers[compilerName] = compiler;
        }

        public static void RemoveCompiler(string compilerName)
        {
            if (compilers[compilerName] != null)
            {
                compilers.Remove(compilerName);
            }
        }

        public static ICompiler GetCompiler(string compilerName)
        {
            return compilers[compilerName];
        }


    }
}
