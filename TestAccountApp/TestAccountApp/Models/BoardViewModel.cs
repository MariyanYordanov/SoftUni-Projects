namespace TestAccountApp.Models
{
    public class BoardViewModel
    {
        public int Id { get; init; }

        public string Name { get; init; } = null!;

        public IEnumerable<MyTaskViewModel> MyTasks { get; set; } = new List<MyTaskViewModel>();
    }
}
