using AuthService.Application.Dto;

namespace AuthService.Application.Interfaces;

public interface IRefreshTokenService
{
    public Task<bool> IsValidToken(Guid userId, string refreshToken);
    public Task SaveRefreshToken(RefreshTokenDto refreshToken);
}