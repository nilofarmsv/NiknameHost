using System;
using System.Collections.Generic;

namespace NikNameHost_ZS.Models
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; }

        public virtual Role IdNavigation { get; set; } = null!;
    }
}
