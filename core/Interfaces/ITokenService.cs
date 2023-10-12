using core.Entities.Identity;

namespace core.Interfaces
{
    public interface ITokenService
    {
        string createToken(User user);
    }
}