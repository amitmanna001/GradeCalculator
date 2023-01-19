using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GradeCalculator.Models
{
    public class GCalculator
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Register Number Can't be Blank")]
        [Display(Name = "Register Number")]
        [Remote(action: "IsStudentRegisterNumberExist", "GCalculators", ErrorMessage = "RegisterNumber already Exists")]
        public int Student_Regno { get; set; }

        [Required(ErrorMessage = "Name Can't be Blank")]
        [RegularExpression("^[a-zA-Z][a-zA-Z ]+[a-zA-Z]$", ErrorMessage = "User Name can't start wtih space and cannot contain any special character")]
        [Display(Name = "Name")]
        public string? Student_Name { get; set; }

        [Required(ErrorMessage = "Department Can't be Blank")]
        [Display(Name = "Class")]
        public string? Student_Dept { get; set; }

        [Required(ErrorMessage = "Subject1 Mark Can't be Blank")]
        [Range(0, 100, ErrorMessage = "Mark Should be between 0 and 100")]
        [Display(Name = "Subject-1")]
        public int Subject1_Mark { get; set; }

        [Required(ErrorMessage = "Subject2 Mark Can't be Blank")]
        [Range(0, 100, ErrorMessage = "Mark Should be between 0 and 100")]
        [Display(Name = "Subject-2")]
        public int Subject2_Mark { get; set; }

        [Required(ErrorMessage = "Subject3 Mark Can't be Blank")]
        [Range(0, 100, ErrorMessage = "Mark Should be between 0 and 100")]
        [Display(Name = "Subject-3")]
        public int Subject3_Mark { get; set; }

        [Display(Name = "Total")]
        public int Total_Mark { get; set; }

        [Display(Name = "Average")]
        public int Average_Mark { get; set; }

        [Required]
        public char Grade { get; set; }

        [Display(Name = "Upload Image")]
        public string? Image_Path { get; set; }

        [NotMapped]
        [Required]
        [Display(Name ="Choose image")]
        public IFormFile? ImageFile { get; set; }
    }
}
