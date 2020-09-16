using System;
using System.Collections.Generic;

namespace Evento.Infrastructure.DTO
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int TicketCounts { get; set; }

        public int PurchasedTicketsCount { get; set; }

        public int AvailableTicketsCount { get; set; }
    }
}