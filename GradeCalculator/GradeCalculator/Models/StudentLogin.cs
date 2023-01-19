using System.ComponentModel.DataAnnotations;

namespace GradeCalculator.Models
{
    public class StudentLogin
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int StudentRegno { get; set; }
    }
}
