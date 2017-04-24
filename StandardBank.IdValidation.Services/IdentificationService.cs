using StandardBank.IdValidation.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StandardBank.IdValidation.Core.Entities;
using System.Text.RegularExpressions;
using System.Globalization;

namespace StandardBank.IdValidation.Services
{
    public class IdentificationService : IIdentificationService
    {
        const int baseYear = 1900;
        const int genderValidator = 5000;
        const int citizenValidator = 0;
        const int femaleValidator = 0;
        const string idValidator = @"^([0-9]){2}([0-1][0-9])([0-3][0-9])([0-9]){4}([0-1])([0-9]){2}?$";

        public Identification Validate(string id, out string validationMessage)
        {
            var identification = new Identification();
            validationMessage = string.Empty;
            var isValid = IsValid(id);
            if (!isValid)
            {
                validationMessage = string.Format("The supplied id ({0}) is invalid ",id);
                return identification;
            }

            identification.Identifier = id;

            var dateOfBirth = ParseDateOfBirth(id);
            identification.DateOfBirth = dateOfBirth;

            var gender = ParseGender(id);
            identification.Gender = gender;

            var citizenship = ParseCitizenship(id);
            identification.Citizenship = citizenship;

            return identification;
        }

        private bool IsValid(string id)
        {
            var regex = new Regex(idValidator);
            var isValid = regex.IsMatch(id);
            return regex.IsMatch(id);
        }
        private DateTime ParseDateOfBirth(string id)
        {
            const int index = 0, length = 6;
            var parsedDate = id.Substring(index, length);
            var dateOfBirth = DateTime.ParseExact(parsedDate, "yyMMdd", CultureInfo.InvariantCulture);
            if (dateOfBirth.Date > DateTime.Now.Date)
                dateOfBirth = dateOfBirth.AddYears(-100);
            return dateOfBirth;
        }

        private string ParseGender(string id)
        {
            const int index = 6, length = 4;
            var parsedGender = id.Substring(index, length);
            var genderValue = Convert.ToInt32(parsedGender);
            return genderValue == femaleValidator ? "Female": "Male";
        }

        private string ParseCitizenship(string id)
        {
            const int index = 10, length = 1;
            var parsedCitizenship = id.Substring(index, length);
            var citizenshipValue = Convert.ToInt32(parsedCitizenship);
            return citizenshipValue == citizenValidator ? "SA" : "Permanent Resident";
        }
    }
}
