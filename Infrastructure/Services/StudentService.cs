using System.Net;
using AutoMapper;
using Domain.ApiResponses;
using Domain.DTOs.StudentDtos;
using Domain.Entities;
using Domain.Filters;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService(DataContext context, IMapper mapper):IStudentService
{
    public async Task<PagedResponse<List<GetStudentDto>>> GetStudentsAsync(StudentFilter filter)
    {
        var validFilter = new ValidFilter(filter.PageNumber, filter.PageSize);
        var query = context.Students.AsQueryable();
        if (!string.IsNullOrEmpty(filter.FullName))
        {
            query = query.Where(s=>($"{s.FirstName} {s.LastName}").ToLower().Trim().Contains(filter.FullName.ToLower()));
        }
        var totalrecords = await query.CountAsync();
        var paged = await query
            .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
            .Take(validFilter.PageSize)
            .ToListAsync();
        var mapped = mapper.Map<List<GetStudentDto>>(paged);
        return new PagedResponse<List<GetStudentDto>>(mapped,totalrecords, validFilter.PageNumber, validFilter.PageSize);
    }

    public async Task<Responce<List<GetStudentDto>>> GetStudentsAsync()
    {
        var students = await context.Students.ToListAsync();
        var mapped = mapper.Map<List<GetStudentDto>>(students);
        return mapped == null
            ? new Responce<List<GetStudentDto>>("Student not found", HttpStatusCode.InternalServerError)
            : new Responce<List<GetStudentDto>>(mapped.ToList(), "Student successfully");
    }

    public async Task<Responce<GetStudentDto>> GetStudentByIdAsync(int id)
    {
        var student = await context.Students.FindAsync(id);
        if (student == null)
        {
            return new Responce<GetStudentDto>("Student not found", HttpStatusCode.Found);
        }
        var mapped = mapper.Map<GetStudentDto>(student);
        return new Responce<GetStudentDto>(mapped, "Student found");
    }

    public async Task<Responce<string>> CreateStudentAsync(CreateStudentDto createStudentDto)
    {
       var mapped = mapper.Map<Student>(createStudentDto);
       await context.Students.AddAsync(mapped);
       var result = await context.SaveChangesAsync();
       return result == 0 
           ? new Responce<string>("Student not created", HttpStatusCode.InternalServerError) 
           : new Responce<string>(null, "Student created successfully");
    }

    public async Task<Responce<string>> UpdateStudentAsync(int id, UpdateStudentDto updateStudentDto)
    {
        var student = await context.Students.FindAsync(id);
        if (student == null)
        {
            return new Responce<string>("Student not found", HttpStatusCode.Found);
        }
        var mapped = mapper.Map<Student>(updateStudentDto);
        context.Students.Update(mapped);
        await context.SaveChangesAsync();
        return new Responce<string>(null, "Student updated successfully");
    }

    public async Task<Responce<string>> DeleteStudentAsync(int id)
    {
        var student = await context.Students.FindAsync(id);
        if (student == null)
        {
            return new Responce<string>("Student not found", HttpStatusCode.Found);
        }
        context.Students.Remove(student);
        await context.SaveChangesAsync();
        return new Responce<string>(null, "Student deleted successfully");
    }
}