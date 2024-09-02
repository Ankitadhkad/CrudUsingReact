using CrudUsingReact.Server.Models;
using CrudUsingReact.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CrudUsingReact.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly StudentRepository _studentRepository;

        public StudentController(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        [HttpPost]
        public async Task<ActionResult>AddStudent([FromBody] ViewModels.StudentRequest studentRequest)
        {
            var student = new Student
            {
                Name = studentRequest.Name,
                Rollno = studentRequest.Rollno,
                Class = studentRequest.Class,
                Address = studentRequest.Address,
                Gender = studentRequest.Gender,



            };


            await _studentRepository.AddStudentAsync(studentRequest);
            return Ok();
        }
        [HttpGet]

        public async Task<ActionResult> GetStudentList()
        {
            var studentList = await _studentRepository.GetAllStudentAsync();
            return Ok(studentList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudentById([FromRoute] int id)
        {
            var employee = await _studentRepository.GetStudentByIdAsync(id);
            return Ok(employee);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent([FromRoute] int id, [FromBody] ViewModels.StudentRequest studentRequest)
        {
            await _studentRepository.UpdateStudentAsync(id, studentRequest);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            await _studentRepository.DeleteStudentAsync(id);
            return Ok();
        }

    }
}
