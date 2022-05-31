using System.ComponentModel.DataAnnotations;

namespace TodoListWeb.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public string? Description { get; set; }
        
        [Required]
        public DateTime Deadline { get; set; }

    }
}
