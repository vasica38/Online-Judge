using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Interfaces
{
    public class Subcription
    {
        public Subcription()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
