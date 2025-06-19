using Domain.DTOs.StudentDtos;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Students;

public class Create(IStudentService studentService) : PageModel
{
    
    
    
    
    [BindProperty] public CreateStudentDto CreateStudentDto {get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await studentService.CreateStudentAsync(CreateStudentDto);
        if (!response.IsSuccess)
        {
            return Page();
        }
        return RedirectToPage("index");
    }
}