using System;
using System.Collections.Generic;

namespace Evento.Core.Domain
{
    public  class Event : Entity
    {
        private ISet<Ticket> _ticket = new HashSet<Ticket>();

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public IEnumerable<Ticket> Tickets { get; protected set; }

        protected Event()
        {

        }

        public Event(Guid id, string name, string descrition, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            Description = descrition;
            StartDate = startDate;
            EndDate = endDate;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddTickets(int amount, decimal price)
        {
            var seating = _ticket.Count + 1;
            for (var i = 0; i < amount; i++)
            {
                _ticket.Add(new Ticket(this, seating, price));
                seating++;
            }
        }
    }
}