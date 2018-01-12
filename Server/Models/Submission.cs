using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public int ProblemId { get; set; }
        public int ContestantId { get; set; }
        public string FileName { get; set; }
        public System.DateTime AcceptedTime { get; set; }
        public int Evaluated { get; set; }
    }
}
