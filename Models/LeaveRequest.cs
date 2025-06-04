using System;
using System.Collections.Generic;

namespace NikNameHost_ZS.Models
{
    public partial class LeaveRequest
    {
        public Guid Id { get; set; }
        public Guid EmploeeId { get; set; }
        public DateTime FormDate { get; set; }
        public DateTime ToDate { get; set; }
      
        public string Status { get; set; } = null!;
        public string Text { get; set; } 
    }
}
