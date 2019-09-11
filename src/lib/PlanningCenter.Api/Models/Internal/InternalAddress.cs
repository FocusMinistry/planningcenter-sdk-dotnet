using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlanningCenter.Api.Models;

namespace PlanningCenter.Api.Models.Internal {
    internal class InternalAddress : BaseModel {
        public InternalAddress() {
            Type = "Address";
        }

        public InternalAddress(Address address) : this() {
            Id = address.Id;
            City = address.City;
            State = address.State;
            Zip = address.Zip;
            Street = address.Street;
            Location = address.Location;
            Primary = address.Primary;
        }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Street { get; set; }

        public string Location { get; set; }

        public bool Primary { get; set; }
    }
}
