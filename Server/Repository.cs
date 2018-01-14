using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    public class Repository
    {
        public IEnumerable<Test> Tests { get; set; }
    }
}
