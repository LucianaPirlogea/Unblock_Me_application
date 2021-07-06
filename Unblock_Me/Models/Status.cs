using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Unblock_Me.Models
{
    public partial class Status
    {
        public string MainLicensePlate { get; set; }
        public string BlockedLicensePlate { get; set; }
        public string BlockedByLicensePlate { get; set; }
        public int? NrBlockedCars { get; set; }
    }
}
