using System.ComponentModel.DataAnnotations;

namespace TestAccountApp.Data.Entities
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)] // with min length 3
        public string Name { get; set; } = null!;
        
        public List<MyTask> Tasks { get; set; } = new List<MyTask>();
    }
}
