using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public class SubmissionResult
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int TestId { get; set; }
        public int StatusId { get; set; }
        public int Time { get; set; }
        public int Memory { get; set; }
        public int Score { get; set; }
        public System.DateTime EvalTime { get; set; }
    }
}
