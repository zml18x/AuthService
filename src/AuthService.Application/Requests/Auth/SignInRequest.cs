namespace AuthService.Application.Requests.Auth;

public record SignInRequest(string Email, string Password);