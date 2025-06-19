using Domain.DTOs.StudentDtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Students;

public class Index(IStudentService studentService) : PageModel
{

    public List<GetStudentDto> Students { get; set; } = [];
    public async Task OnGetAsync()
    {
        var students = await studentService.GetStudents();
        Students = students.Data!;
       

    }
    
}