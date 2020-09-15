namespace Evento.Infrastructure.DTO
{
    public class TokenDTO
    {
        public string Token {get; set;}

        public string Role {get; set;}

        public long Expires {get; set;}
    }
}