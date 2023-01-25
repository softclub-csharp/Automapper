using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public StudentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    //get all students
    public async Task<Response<List<StudentDto>>> GetStudents()
    {
        try
        {
       
            var result =  await _context.Students.ToListAsync();
            var mapped = _mapper.Map<List<StudentDto>>(result);
            return new Response<List<StudentDto>>(mapped);
        }
        catch (Exception ex)
        {
           return new Response<List<StudentDto>>(HttpStatusCode.InternalServerError,new List<string>(){ex.Message});
        }
      
    }


    public async Task<Response<AddStudentDto>> AddStudent(AddStudentDto model)
    {
        try
        {
            var existingStudent = _context.Students.Where(x => x.Phone == model.Phone).FirstOrDefault();
            if (existingStudent != null)
            {
                return new Response<AddStudentDto>(HttpStatusCode.BadRequest,
                    new List<string>() { "Student with this phone already exists" });
            }
            var mapped = _mapper.Map<Student>(model);
            await _context.Students.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddStudentDto>(model);
        }
        catch (Exception e)
        {
        return  new Response<AddStudentDto>(HttpStatusCode.InternalServerError,new List<string>(){e.Message});
        }
        
       
    }
}