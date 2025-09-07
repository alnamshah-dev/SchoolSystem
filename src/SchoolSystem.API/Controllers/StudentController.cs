using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Application.Abstracts.Paginations;
using SchoolSystem.Application.Dtos;
using SchoolSystem.Application.Features.Students.Commands.CreateStudent;
using SchoolSystem.Application.Features.Students.Commands.DeleteStudent;
using SchoolSystem.Application.Features.Students.Commands.UpdateStudent;
using SchoolSystem.Application.Features.Students.Queries.GetStudentById;
using SchoolSystem.Application.Features.Students.Queries.GetStudents;

namespace SchoolSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CreateStudentResult>> CreateStudent(CreateStudentCommand command)
            => Ok(await sender.Send(command));

        [HttpPut]
        public async Task<ActionResult<UpdateStudentResult>> UpdateStudent(UpdateStudentCommand command)
            => Ok(await sender.Send(command));

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteStudentResult>> DeleteStudent(Guid id)
            => Ok(await sender.Send(new DeleteStudentCommand(id)));

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(Guid id)
            => Ok(await sender.Send(new GetStudentByIdQuery(id)));

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<StudentDto>>> GetStudents([FromQuery] PaginationRequest request)
            => Ok(await sender.Send(new GetStudentsQuery(request)));
    }
}
