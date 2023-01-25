using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Domain.Dtos;

public class StudentDto
{
    public int Id { get; set; }
    [Required]
    public string Email { get; set; }
    public Gender Gender { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public DateTime JoinDate { get; set; }
}
