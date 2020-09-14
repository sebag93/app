using System;
using System.Threading.Tasks;
using Evento.Core.Domain;
using System.Collections.Generic;
using src.Evento.Infrastructure.DTO;

namespace src.Evento.Infrastructure.Services
{
    public interface IEventService
    {
        Task<EventDTO> GetAsync(Guid id);

        Task<EventDTO> GetAsync(string name);

        Task<IEnumerable<EventDTO>> BrowseAsync (string name = null);

        Task CreateAsync(Guid id, string name, string description, DateTime startDate, DateTime endDate);

        Task AddTicketAsync(Guid id, int amount, decimal price);

        Task UpdateAsync(Guid id, string name, string description);

        Task DeleteAsync(Guid id);
    }
}