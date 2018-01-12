using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public class ProblemTest
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public string Name { get; set; }
        public string InLocation { get; set; }
        public string OutLocation { get; set; }
        public int Score { get; set; }
    }
}
