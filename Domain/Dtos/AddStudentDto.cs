using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class AddStudentDto : StudentDto
{
    [Required(ErrorMessage = "First name should not be empty")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name should not be empty"),MinLength(5)]
    public string LastName { get; set; }
}