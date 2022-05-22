using Domain.Entities;

namespace Domain.Interfaces.Services.Util
{
    public interface IJWTTokenService
    {
        string CreateToken(User user);
    }
}
