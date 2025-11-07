using System.ComponentModel.DataAnnotations;

namespace ToDoListTask.Validations
{
    public class CustomLengthAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is string result)
            {
                return result.Length > 5 && result.Length < 50;
                    
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The Filed {name} , must have Length must be 5 and 20";
        }

    }
}
