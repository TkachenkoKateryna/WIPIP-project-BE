using Domain.Models.Entities.Identity;

namespace Domain.Interfaces.Services.Util
{
    public interface IJWTTokenService
    {
        string CreateToken(User user);
    }
}
