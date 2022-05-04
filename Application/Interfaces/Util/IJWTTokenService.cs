using Domain.Entities;

namespace Application.Interfaces.Util
{
    public interface IJWTTokenService
    {
        string CreateToken(User user);
    }
}
