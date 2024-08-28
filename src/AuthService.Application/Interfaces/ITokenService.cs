using System.Security.Claims;
using AuthService.Application.Dto;

namespace AuthService.Application.Interfaces;

public interface ITokenService
{
    public JwtDto CreateJwtToken(UserDto user);
    public RefreshTokenDto CreateRefreshToken(Guid userId);
    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
}