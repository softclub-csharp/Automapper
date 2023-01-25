using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
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
    public async Task<List<StudentDto>> GetStudents()
    {
        return await _context.Students.Select(x => new StudentDto()
        {
            Id = x.Id,
            Address = x.Address,
            Email = x.EmailAddress,
            FullName = string.Concat(x.FirstName, x.LastName),
            Gender = x.Gender,
            Phone = x.Phone,
            BirthDate = x.BirthDate,
            JoinDate = x.JoinDate
        }).ToListAsync();
    }


    public async Task<AddStudentDto> AddStudent(AddStudentDto model)
    {
        var mapped = _mapper.Map<Student>(model);
        await _context.Students.AddAsync(mapped);
        await _context.SaveChangesAsync();
        return model;
    }
}