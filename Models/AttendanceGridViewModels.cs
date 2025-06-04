using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikNameHost_ZS.Models
{
    internal class AttendanceGridViewModels
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Name { get; set; } = null!;
        public string Family { get; set; } = null!;
        public string Date { get; set; }
        public string? CheckInTime { get; set; }
        public string? CheckOutTime { get; set; }
        public string? Status { get; set; }
        public string? Text { get; set; }
    }
}
