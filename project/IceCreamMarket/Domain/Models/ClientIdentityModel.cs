using Domain.Contracts;

namespace Domain.Models
{
    public class ClientIdentityModel: IClientIdentity 
    {
        public int? ClientId { get; }
        
        public ClientIdentityModel(int? clientId)
        {
            ClientId = clientId;
        }
    }
}