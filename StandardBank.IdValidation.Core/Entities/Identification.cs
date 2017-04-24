using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardBank.IdValidation.Core.Entities
{
    public class Identification
    {
        public string Identifier { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Citizenship { get; set; }
    }
}
