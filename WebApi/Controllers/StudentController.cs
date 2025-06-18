using Domain.ApiResponses;
using Domain.DTOs.StudentDtos;
using Domain.Filters;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("/api/students")]
public class StudentController(IStudentService studentService) : Controller
{
    [HttpGet("getall")]
    public async Task<PagedResponse<List<GetStudentDto>>> GetStudentsAsync(StudentFilter filter)
    {
        var result = await studentService.GetStudentsAsync(filter);
        return result;
    }
    
}