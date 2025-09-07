using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Application.Abstracts.Paginations;
using SchoolSystem.Application.Dtos;
using SchoolSystem.Application.Features.Schedules.Commands.CreateSchedule;
using SchoolSystem.Application.Features.Schedules.Commands.DeleteSchedule;
using SchoolSystem.Application.Features.Schedules.Commands.UpdateSchedule;
using SchoolSystem.Application.Features.Schedules.Queries.GetScheduleById;
using SchoolSystem.Application.Features.Schedules.Queries.GetSchedules;

namespace SchoolSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController(ISender sender) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<CreateScheduleResult>> CreateSchedule(CreateScheduleCommand command)
            => Ok(await sender.Send(command));

        [HttpPut]
        public async Task<ActionResult<UpdateScheduleResult>> UpdateSchedule(UpdateScheduleCommand command)
            => Ok(await sender.Send(command));

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteScheduleResult>> DeleteSchedule(Guid id)
            => Ok(await sender.Send(new DeleteScheduleCommand(id)));

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleDto>> GetScheduleById(Guid id)
            => Ok(await sender.Send(new GetScheduleByIdQuery(id)));

        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ScheduleDto>>> GetSchedules([FromQuery] PaginationRequest request)
            => Ok(await sender.Send(new GetSchedulesQuery(request)));
    }
}
