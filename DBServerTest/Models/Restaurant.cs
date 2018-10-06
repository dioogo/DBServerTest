using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBServerTest.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Votes { get; set; }
    }
}