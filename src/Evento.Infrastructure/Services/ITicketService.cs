using System;
using System.Threading.Tasks;
using Evento.Infrastructure.DTO;

namespace Evento.Infrastructure.Services
{
    public interface ITicketService
    {
        Task<TicketDTO> GetAsync(Guid userId, Guid eventId, Guid ticketId);
        Task PurchaseAsync(Guid userId, Guid eventId, int amount);
        Task CancelAsync(Guid userId, Guid eventId, int amount);
    }
}