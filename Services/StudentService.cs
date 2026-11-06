using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentRosterDbApi.Data;
using StudentRosterDbApi.DTOs;
using StudentRosterDbApi.Models;

namespace StudentRosterDbApi.Services;

public class StudentService : IStudentService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public StudentService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<StudentDto>> GetAllStudentsAsync()
    {
        var students = await _context.Students
            .Include(s => s.Department)
            .ToListAsync();
        return _mapper.Map<List<StudentDto>>(students);
    }

    public async Task<StudentDto> CreateStudentAsync(StudentCreateDto dto)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var student = _mapper.Map<Student>(dto);
            _context.Students.Add(student);

            var auditLog = new AuditLog { Action = $"Created student: {student.FirstName} {student.LastName}" };
            _context.AuditLogs.Add(auditLog);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return _mapper.Map<StudentDto>(student);
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}