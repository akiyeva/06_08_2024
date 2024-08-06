namespace _06_08_2024.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
