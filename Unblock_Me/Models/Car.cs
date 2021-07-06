using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Unblock_Me.Models
{
    public partial class Car
    {
        public string LicencePlate { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public string SearchTerm { get; set; }
        public string BlockedLicencePlate { get; set; }
        public string BlockedByLicencePlate { get; set; }
        public Guid OwnerId { get; set; }

        public virtual User Owner { get; set; }
    }
}
