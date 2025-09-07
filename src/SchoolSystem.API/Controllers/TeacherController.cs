using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Application.Abstracts.Paginations;
using SchoolSystem.Application.Dtos;
using SchoolSystem.Application.Features.Teachers.Commands.CreateTeacher;
using SchoolSystem.Application.Features.Teachers.Commands.DeleteTeacher;
using SchoolSystem.Application.Features.Teachers.Commands.UpdateTeacher;
using SchoolSystem.Application.Features.Teachers.Queries.GetTeacherById;
using SchoolSystem.Application.Features.Teachers.Queries.GetTeachers;

namespace SchoolSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CreateTeacherResult>> CreateTeacher(CreateTeacherCommand command)
            => Ok(await sender.Send(command));

        [HttpPut]
        public async Task<ActionResult<UpdateTeacherResult>> UpdateTeacher(UpdateTeacherCommand command)
            => Ok(await sender.Send(command));

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteTeacherResult>> DeleteTeacher(Guid id)
            => Ok(await sender.Send(new DeleteTeacherCommand(id)));

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherDto>> GetTeacherById(Guid id)
            => Ok(await sender.Send(new GetTeacherByIdQuery(id)));

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<TeacherDto>>> GetTeachers([FromQuery] PaginationRequest request)
            => Ok(await sender.Send(new GetTeachersQuery(request)));
    }
}
