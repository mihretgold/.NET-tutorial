using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    public class UserRegistrationView:IView
    {
        IFieldValidator _fieldValidator = null;
        IRegister _register = null;

        public IFieldValidator FieldValidator { get => _fieldValidator ;  }

        public UserRegistrationView(IRegister register, IFieldValidator fieldValidator) 
        { 
            _fieldValidator = fieldValidator;
            _register = register;
        }

        
        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteRegistraionHeading();

            _fieldValidator.FieldArray[(int)FieldValidateConstants.UserRegistrationField.EmailAddres] = GetInputFromUser(FieldValidateConstants.UserRegistrationField.EmailAddres, "Plese enter your email address");
            _fieldValidator.FieldArray[(int)FieldValidateConstants.UserRegistrationField.FirstName] = GetInputFromUser(FieldValidateConstants.UserRegistrationField.FirstName, "Plese enter your first name");
            _fieldValidator.FieldArray[(int)FieldValidateConstants.UserRegistrationField.LastName] = GetInputFromUser(FieldValidateConstants.UserRegistrationField.LastName, "Plese enter your last name");
            _fieldValidator.FieldArray[(int)FieldValidateConstants.UserRegistrationField.PhoneNumber] = GetInputFromUser(FieldValidateConstants.UserRegistrationField.PhoneNumber, "Plese enter your phone number");
            _fieldValidator.FieldArray[(int)FieldValidateConstants.UserRegistrationField.Password] = GetInputFromUser(FieldValidateConstants.UserRegistrationField.Password, $"Plese enter your password.{Environment.NewLine}Your Password must contain at least 1 small-case letter, {Environment.NewLine}1 Capital-letter, 1 digit, 1 special-character{Environment.NewLine} and the length should be between 6-10 characters):");
            _fieldValidator.FieldArray[(int)FieldValidateConstants.UserRegistrationField.PasswordCompare] = GetInputFromUser(FieldValidateConstants.UserRegistrationField.PasswordCompare, "Plese enter your password confirm");
            _fieldValidator.FieldArray[(int)FieldValidateConstants.UserRegistrationField.DateofBirth] = GetInputFromUser(FieldValidateConstants.UserRegistrationField.DateofBirth, "Plese enter your Date of Birth");
            _fieldValidator.FieldArray[(int)FieldValidateConstants.UserRegistrationField.AddressFirstLine] = GetInputFromUser(FieldValidateConstants.UserRegistrationField.AddressFirstLine, "Plese enter your Address first line");
            _fieldValidator.FieldArray[(int)FieldValidateConstants.UserRegistrationField.AddressSecondLine] = GetInputFromUser(FieldValidateConstants.UserRegistrationField.AddressSecondLine, "Plese enter your Address second line");
            _fieldValidator.FieldArray[(int)FieldValidateConstants.UserRegistrationField.AddressCity] = GetInputFromUser(FieldValidateConstants.UserRegistrationField.AddressCity, "Plese enter your Address City");
            _fieldValidator.FieldArray[(int)FieldValidateConstants.UserRegistrationField.PostCode] = GetInputFromUser(FieldValidateConstants.UserRegistrationField.PostCode, "Plese enter your post code");

            RegisterUser();

        }

        private void RegisterUser()
        {
            _register.Register(_fieldValidator.FieldArray);
            CommonOutputFormat1.changeFontColor(FontTheme.Success);
            Console.WriteLine("You have Successfully registered!!! Please press any key to Login");
        }

        private string GetInputFromUser(FieldValidateConstants.UserRegistrationField field, string promptText)
        {
            string fieldVal = "";

            do
            {
                Console.Write(promptText);
                fieldVal = Console.ReadLine();

            } while (!FieldValid(field, fieldVal));
            return fieldVal;
        }

        private bool FieldValid(FieldValidateConstants.UserRegistrationField field, string fieldValue)
        {
            if(!_fieldValidator.ValidatorDel((int)field , fieldValue,_fieldValidator.FieldArray, out string invalidMessage))
            {
                CommonOutputFormat1.changeFontColor(FontTheme.Danger);
                Console.WriteLine(invalidMessage);
                CommonOutputFormat1.changeFontColor(FontTheme.Default);
                return false;
            }
            
            return true;
        }
    }
}
