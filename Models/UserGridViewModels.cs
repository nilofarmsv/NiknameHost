using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikNameHost_ZS.Models
{
    internal class UserGridViewModels
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Family { get; set; } = null!;
        public string NationalCode { get; set; } = null!;
        public string? Phone { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Position { get; set; } = null!;
        public byte[] filePath { get; set; }
    }
}
