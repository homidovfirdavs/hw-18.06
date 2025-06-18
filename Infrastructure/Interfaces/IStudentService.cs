using Domain.ApiResponses;
using Domain.DTOs.StudentDtos;
using Domain.Entities;
using Domain.Filters;

namespace Infrastructure.Interfaces;

public interface IStudentService
{
    Task<PagedResponse<List<GetStudentDto>>> GetStudentsAsync(StudentFilter filter);
    Task<Responce<List<GetStudentDto>>> GetStudentsAsync();
    Task<Responce<GetStudentDto>> GetStudentByIdAsync(int id);
    Task<Responce<string>> CreateStudentAsync(CreateStudentDto createStudentDto);
    Task<Responce<string>> UpdateStudentAsync(int id, UpdateStudentDto updateStudentDto);
    Task<Responce<string>> DeleteStudentAsync(int id);
}