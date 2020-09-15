using System;
using System.Threading.Tasks;
using Evento.Infrastructure.DTO;

namespace Evento.Infrastructure.Services
{
    public interface IUserService
    {
        Task<AccountDTO> GetAccountAsync(Guid userId);

        Task RegisterAsync(Guid userId, string email, 
        string name, string password, string role = "user");

        Task<TokenDTO> LoginAsync(string email, string password);
    }
}