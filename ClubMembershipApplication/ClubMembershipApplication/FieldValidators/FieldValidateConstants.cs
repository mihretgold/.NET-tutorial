using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.FieldValidators
{
    public class FieldValidateConstants
    {
        public enum UserRegistrationField
        {
            EmailAddres, 
            FirstName,
            LastName,
            Password,
            PasswordCompare,
            DateofBirth, 
            PhoneNumber, 
            AddressFirstLine,
            AddressSecondLine,
            AddressCity,
            PostCode
        }
    }
}
