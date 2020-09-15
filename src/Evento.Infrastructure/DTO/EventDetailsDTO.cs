using System.Collections.Generic;

namespace src.Evento.Infrastructure.DTO
{
    public class EventDetailsDTO : EventDTO
    {
        public IEnumerable<TicketDTO> Tickets { get; set; }
    }
}