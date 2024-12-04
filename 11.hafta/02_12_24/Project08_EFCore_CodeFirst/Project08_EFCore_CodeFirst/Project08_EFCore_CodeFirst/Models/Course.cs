namespace Project08_EFCore_CodeFirst.Models
{
    public class Course
    {
        public int Id{ get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
