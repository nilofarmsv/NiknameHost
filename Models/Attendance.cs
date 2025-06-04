using System;
using System.Collections.Generic;

namespace NikNameHost_ZS.Models
{
    public partial class Attendance
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string? Status { get; set; }
        public string? Text { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
