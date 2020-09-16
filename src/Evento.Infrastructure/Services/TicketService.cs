using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Evento.Core.Repositories;
using Evento.Infrastructure.DTO;
using Evento.Infrastructure.Extensions;

namespace Evento.Infrastructure.Services
{
    public class TicketService : ITicketService
    {
        private IUserRepository _userRepository;
        private IEventRepository _eventRepository;
        private IMapper _mapper;

        public TicketService(IUserRepository userRepository, 
        IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketDTO>> GetForUserAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var events = await _eventRepository.BrowseAsync();
            
            var tickets = events.SelectMany(x => x.GetTicketsPurchasedByUser(user));

            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }

        public async Task<TicketDTO> GetAsync(Guid userId, Guid eventId, Guid ticketId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var ticket = _eventRepository.GetTicketOrFailAsync(eventId, ticketId);

            return _mapper.Map<TicketDTO>(ticket);
        }

        public async Task PurchaseAsync(Guid userId, Guid eventId, int amount)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var @event = await _eventRepository.GetOrFailAsync(eventId);
            @event.PurchaseTickets(user, amount);
            await _eventRepository.UpdateAsync(@event);
        }

        public async Task CancelAsync(Guid userId, Guid eventId, int amount)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var @event = await _eventRepository.GetOrFailAsync(eventId);
            @event.CancelPurchasedTickets(user, amount);
            await _eventRepository.UpdateAsync(@event);
        }
    }
}