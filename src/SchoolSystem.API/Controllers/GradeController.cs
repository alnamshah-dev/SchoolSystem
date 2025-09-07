using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Application.Abstracts.Paginations;
using SchoolSystem.Application.Dtos;
using SchoolSystem.Application.Features.Grades.Commands.CreateGrade;
using SchoolSystem.Application.Features.Grades.Commands.DeleteGrade;
using SchoolSystem.Application.Features.Grades.Commands.UpdateGrade;
using SchoolSystem.Application.Features.Grades.Queries.GetGradeById;
using SchoolSystem.Application.Features.Grades.Queries.GetGrades;

namespace SchoolSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CreateGradeResult>> CreateGrade(CreateGradeCommand command)
            => Ok(await sender.Send(command));

        [HttpPut]
        public async Task<ActionResult<UpdateGradeResult>> UpdateGrade(UpdateGradeCommand command)
            => Ok(await sender.Send(command));

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteGradeResult>> DeleteGrade(Guid id)
            => Ok(await sender.Send(new DeleteGradeCommand(id)));

        [HttpGet("{id}")]
        public async Task<ActionResult<GradeDto>> GetGradeById(Guid id)
            => Ok(await sender.Send(new GetGradeByIdQuery(id)));

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<GradeDto>>> GetGrades([FromQuery] PaginationRequest request)
            => Ok(await sender.Send(new GetGradesQuery(request)));
    }
}
