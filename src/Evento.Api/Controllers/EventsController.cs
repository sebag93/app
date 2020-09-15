using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Evento.Infrastructure.Commands.Events;
using src.Evento.Infrastructure.Services;

namespace src.Evento.Api.Controllers
{
    [Route("[controller]")]
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var events = await _eventService.BrowseAsync(name);

            return Json(events);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateEvent command)
        {
            command.EventId = Guid.NewGuid();
            await _eventService.CreateAsync(command.EventId,command.Name,command.Description,command.StartDate, command.EndDate);

            // location header
            return Created($"/events/{command.EventId}", null);
        }
    }
}