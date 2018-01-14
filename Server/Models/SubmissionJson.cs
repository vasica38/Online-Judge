using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public class SubmissionJson
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public string Code { get; set; }

        public string Language { get; set; }

        public string SubmissionAccountId { get; set; }

        public int SubmissionProblemId { get; set; }
    }
    
}
