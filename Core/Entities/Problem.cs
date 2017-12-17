using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Problem: BaseEntity
    {
        public string Name { get; set; }
        /// <summary>
        /// details about problem.
        /// </summary>
        public string Json { get; set; }
    }
}
