using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.MapperProfiles;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Student, StudentDto>()
            .ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"))
            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.EmailAddress))
            .ForMember(x=>x.Gender,opt=>opt.MapFrom(x=>x.Gender == Gender.Male ? "Male" : "Female"))
            .ForMember(x=>x.Gender, opt=>opt.Ignore());
        CreateMap<AddStudentDto, Student>();
    }
}