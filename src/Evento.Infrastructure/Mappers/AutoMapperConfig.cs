using System.Linq;
using AutoMapper;
using Evento.Core.Domain;
using Evento.Infrastructure.DTO;

namespace Evento.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event,EventDTO>()
                    .ForMember(x => x.AvailableTicketsCount, m => m.MapFrom(p => p.AvailableTickets.Count()))
                    .ForMember(x => x.PurchasedTicketsCount, m => m.MapFrom(p => p.PurchasedTickets.Count()))
                    .ForMember(x => x.TicketCounts, m => m.MapFrom(p => p.Tickets.Count()))
                    ;
                cfg.CreateMap<Event,EventDetailsDTO>();
                cfg.CreateMap<Ticket,TicketDTO>();
                cfg.CreateMap<User,AccountDTO>();
            })
            .CreateMapper();
    }
}