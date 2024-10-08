﻿using FluentValidation;
using AuthService.Application.Common.Validation;

namespace AuthService.Application.Requests.Auth.Validators;

public class RegisterRequestValidator : AbstractValidator<UserRegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotNull().WithMessage("Email is required.")
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.Password)
            .MatchPassword();

        RuleFor(x => x.PhoneNumber)
            .MatchPhoneNumber();
    }
}