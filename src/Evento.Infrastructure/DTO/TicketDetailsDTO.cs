using System;
namespace Evento.Infrastructure.DTO
{
    public class TicketDetailsDTO : TicketDTO
    {
        public Guid eventId {get; set;}
        public string EventName {get; set;}
    }
}