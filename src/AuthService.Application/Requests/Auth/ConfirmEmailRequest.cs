﻿namespace AuthService.Application.Requests.Auth;

public record ConfirmEmailRequest(string Email, string Token);