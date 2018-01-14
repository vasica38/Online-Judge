using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public class Execution
    {
        public Execution(bool hasTerminated, int totalMs, double usedMemoryKBs, string output, bool hasOutputFile)
        {
            HasTerminated = hasTerminated;
            TotalMs = totalMs;
            UsedMemoryKBs = usedMemoryKBs;
            Output = output;
            HasOutputFile = hasOutputFile;
        }

        public bool HasTerminated { get; set; }
        public int TotalMs { get; set; }
        public double UsedMemoryKBs { get; set; }
        public string Output { get; set; }
        public bool HasOutputFile { get; set; }

    }
}
