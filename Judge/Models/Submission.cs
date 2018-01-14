using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Judge.Models
{
    public class Submission
    {
        public int Id { get; set; }

        public int Score { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Language { get; set; }

        [Required]
        public string SubmissionAccountId { get; set; }

        [Required]
        public int SubmissionProblemId { get; set; }
    }
}