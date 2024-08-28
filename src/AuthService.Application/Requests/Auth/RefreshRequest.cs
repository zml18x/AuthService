namespace AuthService.Application.Requests.Auth;

public record RefreshRequest(string AccessToken, string RefreshToken);