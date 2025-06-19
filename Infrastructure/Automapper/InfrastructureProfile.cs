using AutoMapper;
using Domain.DTOs.StudentDtos;
using Domain.Entities;

namespace Infrastructure.Automapper;

public class InfrastructureProfile: Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Student, GetStudentDto>();
        CreateMap<CreateStudentDto, Student>();
        CreateMap<UpdateStudentDto, Student>();
    }
}
