using StandardBank.IdValidation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardBank.IdValidation.Core.Services
{
    public interface IIdentificationService
    {
        Identification Validate(string Id, out string validationResult);
    }
}
