using System;
using System.Threading.Tasks;
using Evento.Core.Domain;

namespace Evento.Core.Repositories
{
    public interface IUserRepository
    {
         Task<User> GetAsync(Guid id);

         Task<User> GetAsync(string email);

         Task AddSync(User user);

         Task UpdateSync(User user);

         Task DeleteAsync(User user);
    }
}