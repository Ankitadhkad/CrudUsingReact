using CrudUsingReact.Server.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CrudUsingReact.Server.Models
{
    public class StudentRepository
    {
        private readonly StudentContext _studentContext;

        public StudentRepository(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        public async Task AddStudentAsync(StudentRequest studentRequest)
        {
            var student = new Student
            {
                Name = studentRequest.Name,
                Rollno = studentRequest.Rollno,
                Class = studentRequest.Class,
                Address = studentRequest.Address,
                Gender = studentRequest.Gender,



            };
            await _studentContext.Students.AddAsync(student);
            await _studentContext.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _studentContext.Students.ToListAsync();
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _studentContext.Students.FindAsync(id);
        }
        public async Task UpdateStudentAsync(int id, StudentRequest studentRequest)
        {
            var student = await _studentContext.Students.FindAsync(id);
            if (student == null)
            {
                throw new Exception("Employee not found");
            }

            student.Name = studentRequest.Name;
            student.Rollno = studentRequest.Rollno;
            student.Class = studentRequest.Class;
            student.Address = studentRequest.Address;
            student.Gender = studentRequest.Gender;

            await _studentContext.SaveChangesAsync();
        }
        public async Task DeleteStudentAsync(int id)
        {
            try
            {
                var student = await _studentContext.Students.FindAsync(id);
                if (student == null)
                {
                    throw new Exception("Employee not found");
                }
                _studentContext.Students.Remove(student);
                await _studentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }


        }

    }
}
