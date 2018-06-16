using System;
using System.Collections.Generic;
using System.Text;

namespace RadamsaServer.Models
{
    public class FuzzRequest
    {
        public int Ammount { get; set; } = 1;
        public string Input { get; set; }
        public string Seed { get; set; } = null;
    }
}
