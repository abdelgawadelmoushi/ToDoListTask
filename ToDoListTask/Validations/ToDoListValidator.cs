
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ToDoListTask.Models;

namespace ToDoListTask.Validations
{
    public class ToDoListValidator : AbstractValidator<ToDoList>
    {
        private readonly object PropertyName;
        private readonly object MinLength;
        private readonly object MaxLength;

        public ToDoListValidator()
        {
           RuleFor(e=>e.Title).NotEmpty()
                .Length(5,50)
                //.Must(e=>e.Length >5 && e.Length <50 ).NotEmpty()
                //.MinimumLength(5)
                //.MaximumLength(50)
                .WithMessage($"The Filed {PropertyName} , must have Length must be {MinLength} and {MaxLength}");

        }

     
    }
}
