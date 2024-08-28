namespace AuthService.Application.Requests.Auth;

public record ChangePasswordRequest(string CurrentPassword, string NewPassword);