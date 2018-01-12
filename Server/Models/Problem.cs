using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public class Problem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimeLimit { get; set; }
        public int MemoryLimit { get; set; }
        public string Text { get; set; }
        
    }
}
