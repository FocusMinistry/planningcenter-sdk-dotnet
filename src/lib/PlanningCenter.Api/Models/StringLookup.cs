using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningCenter.Api.Models {
    public class StringLookup {
        public StringLookup() { }

        public StringLookup(string type, string id) {
            Type = type;
            Id = id;
        }

        public string Type { get; set; }

        public string Id { get; set; }
    }
}
