using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Unblock_Me.Models
{
    public partial class User: IdentityUser
    {
        public User()
        {
            Car = new HashSet<Car>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Rating { get; set; }

        public virtual ICollection<Car> Car { get; set; }

    }
}
