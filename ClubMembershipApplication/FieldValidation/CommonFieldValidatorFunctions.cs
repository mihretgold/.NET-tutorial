using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidation
{
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDate);
    public delegate bool PatternMatchDel(string fieldVal, string pattern);
    public delegate bool CompareFieldValidDel(string fieldVal, string fieldValCompare);
    public class CommonFieldValidatorFunctions
    {
        private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringLengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatchDel _patternMatchDel = null;
        private static CompareFieldValidDel _compareFieldValidDel = null;

        public static RequiredValidDel RequiredValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);
                
                return _requiredValidDel;
            }
        }

        public static StringLengthValidDel StringLengthValidDel
        {
            get
            {
                if (_stringLengthValidDel == null)
                    _stringLengthValidDel = new StringLengthValidDel(StringFieldLengthValid);

                return _stringLengthValidDel;
            }
        }

        public static DateValidDel DateValidDel
        {
            get
            {
                if (_dateValidDel == null)
                    _dateValidDel = new DateValidDel(DateFieldValid);

                return _dateValidDel;
            }
        }

        public static PatternMatchDel PatternMatchDel
        {
            get
            {
                if (_patternMatchDel == null)
                    _patternMatchDel = new PatternMatchDel(FieldPatternValid);

                return _patternMatchDel;
            }
        }

        public static CompareFieldValidDel CompareFieldValidDel
        {
            get
            {
                if (_compareFieldValidDel == null)
                    _compareFieldValidDel = new CompareFieldValidDel(FieldComparisonValid);

                return _compareFieldValidDel;
            }
        }
        private static bool RequiredFieldValid(string fieldVal)
        {
            if(!string.IsNullOrEmpty(fieldVal))
            {
                return true;
            }
            return false;
        }

        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
            {
                return true;
            }
            return false;
        }
        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            //out is a way for the method calling class to get the paresd valid date since we already returing boolean we can't return it
            if (DateTime.TryParse(dateTime, out validDateTime))
            {
                return true;
            }
            return false;
        }

        private static bool FieldPatternValid(string fieldVal, string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);

            if (regex.IsMatch(fieldVal))
            {
                return true;
            }
            return false;
        }

        private static bool FieldComparisonValid(string field1, string field2)
        {
            if (field1.Equals(field2))
            {
                return true;
            }
            return false;
        }
    }
}
