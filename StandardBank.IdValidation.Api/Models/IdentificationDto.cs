using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StandardBank.IdValidation.Api.Models
{
    public class IdentificationDto
    {
        public string Identifier { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Citizenship { get; set; }
    }
}