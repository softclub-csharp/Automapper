using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

// [ApiController]
[Route("[controller]")]
public class StudentController:ControllerBase
{
    private readonly StudentService _service;

    public StudentController(StudentService service)
    {
        _service = service;
    }
    
    [HttpGet]
    public async Task<Response<List<StudentDto>>> Get()
    {
        return await _service.GetStudents();
    }
    
    [HttpPost]
    public async  Task<Response<AddStudentDto>> Add(AddStudentDto student)
    {
        if (ModelState.IsValid)
        { 
            return await _service.AddStudent(student);
        }
        else
        {
            
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddStudentDto>(HttpStatusCode.BadRequest, errors);
        }
       
    }

}