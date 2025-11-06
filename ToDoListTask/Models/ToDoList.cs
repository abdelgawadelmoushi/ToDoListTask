using System.ComponentModel.DataAnnotations;

namespace ToDoListTask.Models
{
    public class ToDoList
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="This field is required") , MinLength(4) , MaxLength(50)]
        public string Title { get; set; }=string.Empty;

        [MinLength(5)]
        public string Discreption { get; set; } = string.Empty;
        public string File { get; set; } = "default.txt";
        public DateTime Deadline { get; set; }  


    }
}
