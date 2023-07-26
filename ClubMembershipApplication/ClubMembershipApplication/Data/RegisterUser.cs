using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Data
{
    public class RegisterUser : IRegister
    {
        public bool EmailExist(string emailAddress)
        {
            bool emailExists = false ;
            
            using (var dbCotext = new ClubMembershipDbContext())
            {
                emailExists = dbCotext.Users.Any(u => u.EmailAddress.ToLower().Trim() == emailAddress.Trim());
            }
            return emailExists;
        }

        public bool Register(string[] fields)
        {
            using (var dbContext = new ClubMembershipDbContext())
            {
                User user = new User
                {
                    EmailAddress = fields[(int)FieldValidateConstants.UserRegistrationField.EmailAddres],
                    FirstName = fields[(int)FieldValidateConstants.UserRegistrationField.FirstName],
                    LastName = fields[(int)FieldValidateConstants.UserRegistrationField.LastName],
                    Password = fields[(int)FieldValidateConstants.UserRegistrationField.Password],
                    PhoneNumber = fields[(int)FieldValidateConstants.UserRegistrationField.PhoneNumber],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldValidateConstants.UserRegistrationField.DateofBirth]),
                    AddressFirstLine = fields[(int)FieldValidateConstants.UserRegistrationField.AddressFirstLine],
                    AddressSecondLine = fields[(int)FieldValidateConstants.UserRegistrationField.AddressSecondLine],
                    AddressCity = fields[(int)FieldValidateConstants.UserRegistrationField.AddressCity],
                    PostCode = fields[(int)FieldValidateConstants.UserRegistrationField.PostCode]
                };
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            return true;
        }
    }
}
