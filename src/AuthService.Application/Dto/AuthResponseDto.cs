namespace AuthService.Application.Dto;

public record AuthResponseDto(string AccessToken, DateTime AccessTokenExpiration, string RefreshToken,
    DateTime RefreshTokenExpiration);