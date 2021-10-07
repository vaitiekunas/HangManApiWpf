using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangManApi.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastUpdate { get; set; }
        public string FullName { get {return FirstName + " " + LastName.ToString();}}
    }
}
