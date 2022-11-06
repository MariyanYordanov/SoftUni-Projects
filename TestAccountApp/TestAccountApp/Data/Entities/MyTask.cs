using System.ComponentModel.DataAnnotations;

namespace TestAccountApp.Data.Entities
{
    public class MyTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(70)] //with min length 5
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(1000)] // with min length 10
        public string Description { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; init; }

        public Board Board { get; set; } = null!;

        [Required]
        public string OwnerId { get; set; } = null!;

        public MyUser Owner { get; init; } = null!;
    }
}
