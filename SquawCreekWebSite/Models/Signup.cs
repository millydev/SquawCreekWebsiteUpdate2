using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SquawCreekWebSite.Models
{
    public class Signup
    {
        private int v1;
        private string v2;
        private string v3;

        public Signup(int v1, string v2, string v3)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
    }
}