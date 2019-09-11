using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningCenter.Api.Models {
    public class Lookup {
        public Lookup() { }

        public Lookup(string type, int id) {
            Type = type;
            Id = id;
        }

        public string Type { get; set; }

        public int Id { get; set; }
    }
}
