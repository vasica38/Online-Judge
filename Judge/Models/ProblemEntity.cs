using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
 
namespace Judge.Models
{
    public class ProblemEntity
    {
        public int Id { get; set; }
 
        [Required]
        [Display(Name = "Problem Name")]
        public string Name { get; set; }
 
        [Required]
        [Display(Name = "Problem Text")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
 
        [Required]
        [Display(Name = "Memory Limit Kb")]
        public int MemoryLimitKb { get; set; }
 
        [Required]
        [Display(Name = "Timit Limit in Ms")]
        public int TymeLimitMs { get; set; }
 
        [Required]
        public string In { get; set; }
 
        [Required]
        public string Out { get; set; }
 
        [Required]
        public string Author { get; set; }
 
        public virtual ApplicationUser User { get; set; }
 
        [Required]
        public string ApplicationUserId { get; set; }
 
        public virtual ICollection<Submission> Submissions { get; set; }
 
    }
}