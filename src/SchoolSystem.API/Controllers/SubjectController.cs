using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Application.Abstracts.Paginations;
using SchoolSystem.Application.Dtos;
using SchoolSystem.Application.Features.Subjects.Commands.CreateSubject;
using SchoolSystem.Application.Features.Subjects.Commands.DeleteSubject;
using SchoolSystem.Application.Features.Subjects.Commands.UpdateSubject;
using SchoolSystem.Application.Features.Subjects.Queries.GetSubjectById;
using SchoolSystem.Application.Features.Subjects.Queries.GetSubjects;

namespace SchoolSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CreateSubjectResult>> CreateSubject(CreateSubjectCommand command)
            => Ok(await sender.Send(command));

        [HttpPut]
        public async Task<ActionResult<UpdateSubjectResult>> UpdateSubject(UpdateSubjectCommand command)
            => Ok(await sender.Send(command));

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteSubjectResult>> DeleteSubject(Guid id)
            => Ok(await sender.Send(new DeleteSubjectCommand(id)));

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetSubjectById(Guid id)
            => Ok(await sender.Send(new GetSubjectByIdQuery(id)));

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<SubjectDto>>> GetSubjects([FromQuery] PaginationRequest request)
            => Ok(await sender.Send(new GetSubjectsQuery(request)));
    }
}
