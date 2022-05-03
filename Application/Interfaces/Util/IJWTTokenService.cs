using Domain.Entities;
using Domain.Entities.Util;

namespace Application.Interfaces.Util
{
    public interface IJWTTokenService
    {
        string CreateToken(User user);
        RefreshToken GenerateRefreshToken();
    }
}
