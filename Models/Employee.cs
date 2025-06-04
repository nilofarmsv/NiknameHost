using System;
using System.Collections.Generic;

namespace NikNameHost_ZS.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Attendances = new HashSet<Attendance>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Family { get; set; } = null!;
        public string NationalCode { get; set; } = null!;
        public string? Phone { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Position { get; set; } = null!;
        public byte[] filePath { get; set; } 
        public DateTime? HireDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        
    }
}
