using System.ComponentModel.DataAnnotations;
using ToDoListTask.Validations;

namespace ToDoListTask.Models
{
    public class ToDoList
    {
        public int Id { get; set; }


        [Required , CustomLength]
        public string Title { get; set; }=string.Empty;

        [CustomLength]
        public string Discreption { get; set; } = string.Empty;
        public string File { get; set; } = "default.txt";

     
        public DateTime Deadline { get; set; }  


    }
}
