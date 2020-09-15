using System;
using Evento.Infrastructure.DTO;

namespace Evento.Infrastructure.Services
{
    public interface IJwtHandler
    {
        JwtDTO CreateToken(Guid userId, string role);
    }
}