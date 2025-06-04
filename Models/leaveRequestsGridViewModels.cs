using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikNameHost_ZS.Models
{
    internal class leaveRequestsGridViewModels
    {
        public Guid Id { get; set; }
        public Guid EmploeeId { get; set; }
        public string FormDate { get; set; }
        public string ToDate { get; set; }
        public string Name { get; set; } = null!;
        public string Family { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Text { get; set; }
    }
}
