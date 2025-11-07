using System.ComponentModel.DataAnnotations;
using ToDoListTask.Validations;
using FluentValidation;


namespace ToDoListTask.Models
{
    public class ToDoList
    {
        public int Id { get; set; }


        [Required , CustomLength(5,50)]
        public string Title { get; set; }=string.Empty;

        [CustomLength(5,150)]
        public string Discreption { get; set; } = string.Empty;
        public string File { get; set; } = "default.txt";

     
        public DateTime Deadline { get; set; }  


    }
}
