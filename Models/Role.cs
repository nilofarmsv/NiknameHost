using System;
using System.Collections.Generic;

namespace NikNameHost_ZS.Models
{
    public partial class Role
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public bool Isok { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
