using FluentValidation;
using AuthService.Application.Common.Validation;

namespace AuthService.Application.Requests.Auth.Validators;

public class SendResetPasswordTokenRequestValidator : AbstractValidator<SendResetPasswordTokenRequest>
{
    public SendResetPasswordTokenRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotNull().WithMessage("Email is required.")
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.NewPassword)
            .MatchPassword();
    }
}