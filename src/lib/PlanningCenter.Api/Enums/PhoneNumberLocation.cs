using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PlanningCenter.Api.Enums {
    public enum PhoneNumberLocation {
        [Description("Mobile")]
        Mobile,
        [Description("Home")]
        Home,
        [Description("Work")]
        Work,
        [Description("Pager")]
        Pager,
        [Description("Fax")]
        Fax,
        [Description("Other")]
        Other
    }
}
