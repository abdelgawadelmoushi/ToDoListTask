using System.ComponentModel.DataAnnotations;

namespace ToDoListTask.Validations
{
    public class CustomLengthAttribute : ValidationAttribute
    {
        private readonly int _minLength;
        private readonly int _maxLenght;

        public CustomLengthAttribute(int minLength , int maxLength) {

            _minLength = minLength;
            _maxLenght = maxLength;
        }
        public override bool IsValid(object? value)
        {
            if (value is string result)
            {
                return result.Length > _minLength && result.Length < _maxLenght;
                    
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The Filed {name} , must have Length must be 5 and 20";
        }

    }
}
