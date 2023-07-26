using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMembershipApplication.Data;
using FieldValidation;

namespace ClubMembershipApplication.FieldValidators
{
    public class UserRegistratioValidator : IFieldValidator
    {
        const int FirstName_Min_Length = 2;
        const int FirstName_Max_Length = 100;
        const int LastName_Min_Length = 2;
        const int LastName_Max_Length = 100;

        delegate bool EmailExistsDel(string email);

        FieldValidatorDel _fieldValidatorDel = null;
        RequiredValidDel _requiredValidDel = null;
        StringLengthValidDel _stringLengthValidDel = null;
        DateValidDel _dateValidDel = null;
        PatternMatchDel _patternMatchDel = null;
        CompareFieldValidDel _compareFieldValidDel = null;

        EmailExistsDel _emailExistsDel = null;

        string[] _fieldArray = null;
        IRegister _register = null;

        public string[] FieldArray
        {
            get
            {
                if(_fieldArray == null)
                {
                    _fieldArray = new string[Enum.GetValues(typeof(FieldValidateConstants.UserRegistrationField)).Length];
                }
                return _fieldArray;
            }
        }

        public FieldValidatorDel ValidatorDel => _fieldValidatorDel;

        public UserRegistratioValidator(IRegister register)
        {
            _register = register;
        }
        public void InitliseValidatorDelegates()
        {
            _fieldValidatorDel = new FieldValidatorDel(ValidateField);
            _emailExistsDel = new EmailExistsDel(_register.EmailExist);

            _requiredValidDel = CommonFieldValidatorFunctions.RequiredValidDel;
            _stringLengthValidDel = CommonFieldValidatorFunctions.StringLengthValidDel;
            _dateValidDel = CommonFieldValidatorFunctions.DateValidDel;
            _compareFieldValidDel = CommonFieldValidatorFunctions.CompareFieldValidDel;
            _patternMatchDel = CommonFieldValidatorFunctions.PatternMatchDel;


        }

        private bool ValidateField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = "";

            FieldValidateConstants.UserRegistrationField userRegistrationField = (FieldValidateConstants.UserRegistrationField)fieldIndex;
            switch (userRegistrationField)
            {
                case FieldValidateConstants.UserRegistrationField.EmailAddres:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldValidateConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchDel(fieldValue, CommonRegularExpressionPatterns.Email_Address_RegEx_Pattern)) ? $"You must enter a valid email address:{Environment.NewLine}" : fieldInvalidMessage;
                    fieldInvalidMessage = (fieldInvalidMessage == "" && _emailExistsDel(fieldValue)) ? $"Ther email address already exists. Please try again{Environment.NewLine}" : fieldInvalidMessage;
                    break;

                case FieldValidateConstants.UserRegistrationField.FirstName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldValidateConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLengthValidDel(fieldValue, FirstName_Min_Length, FirstName_Max_Length)) ? $"must be between {FirstName_Min_Length} and {FirstName_Max_Length}:{Environment.NewLine}" : fieldInvalidMessage;
                    break;
                
                case FieldValidateConstants.UserRegistrationField.LastName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldValidateConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLengthValidDel(fieldValue, LastName_Min_Length, LastName_Max_Length)) ? $"must be between {LastName_Min_Length} and {LastName_Max_Length}:{Environment.NewLine}" : fieldInvalidMessage;
                    break;

                case FieldValidateConstants.UserRegistrationField.Password:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldValidateConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchDel(fieldValue, CommonRegularExpressionPatterns.Strong_Password_RegEx_Pattern)) ? $"Your password must contain at least 1 small-case letter, 1 capital letter, 1 special character and the length should be between 6 - 10 characters" : fieldInvalidMessage;
                    break;

                case FieldValidateConstants.UserRegistrationField.PasswordCompare:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldValidateConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_compareFieldValidDel(fieldValue, fieldArray[(int)FieldValidateConstants.UserRegistrationField.Password])) ? $"Your entry did not match your password{ Environment.NewLine}" : fieldInvalidMessage;
                    break;


                case FieldValidateConstants.UserRegistrationField.DateofBirth:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldValidateConstants.UserRegistrationField), userRegistrationField)}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_dateValidDel(fieldValue, out DateTime validDateTime)) ? $"You did not enter a valid date:{Environment.NewLine}" : fieldInvalidMessage;
                    break;

                case FieldValidateConstants.UserRegistrationField.PhoneNumber:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldValidateConstants.UserRegistrationField), userRegistrationField)}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchDel(fieldValue, CommonRegularExpressionPatterns.Uk_PhoneNumber_RegEx_Pattern)) ? $"You did not enter a valid Phone number:" : fieldInvalidMessage;
                    break;

                case FieldValidateConstants.UserRegistrationField.AddressFirstLine:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldValidateConstants.UserRegistrationField), userRegistrationField)}" : "";
                    break;

                case FieldValidateConstants.UserRegistrationField.AddressSecondLine:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldValidateConstants.UserRegistrationField), userRegistrationField)}" : "";
                    break;

                case FieldValidateConstants.UserRegistrationField.AddressCity:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldValidateConstants.UserRegistrationField), userRegistrationField)}" : "";
                    break;

                case FieldValidateConstants.UserRegistrationField.PostCode:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldValidateConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchDel(fieldValue, CommonRegularExpressionPatterns.Uk_Post_Code_RegEx_Pattern)) ? $"You did not enter a valid UK-Post code" : fieldInvalidMessage;
                    break;

                default:
                    throw new ArgumentException("This field does not exists");
                    



            }
            return (fieldInvalidMessage == "");
        }
    }
}
