using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Application.Abstracts.Paginations;
using SchoolSystem.Application.Dtos;
using SchoolSystem.Application.Features.Classes.Commands.CreateClass;
using SchoolSystem.Application.Features.Classes.Commands.DeleteClass;
using SchoolSystem.Application.Features.Classes.Commands.UpdateClass;
using SchoolSystem.Application.Features.Classes.Queries.GetClassById;
using SchoolSystem.Application.Features.Classes.Queries.GetClasses;

namespace SchoolSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CreateClassResult>> CreateClass(CreateClassCommand command)
            => Ok(await sender.Send(command));

        [HttpPut]
        public async Task<ActionResult<UpdateClassResult>> UpdateClass(UpdateClassCommand command)
            => Ok(await sender.Send(command));

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteClassResult>> DeleteClass(Guid id)
            => Ok(await sender.Send(new DeleteClassCommand(id)));

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDto>> GetClassById(Guid id)
            => Ok(await sender.Send(new GetClassByIdQuery(id)));

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ClassDto>>> GetClasses([FromQuery] PaginationRequest request)
            => Ok(await sender.Send(new GetClassesQuery(request)));
    }
}
