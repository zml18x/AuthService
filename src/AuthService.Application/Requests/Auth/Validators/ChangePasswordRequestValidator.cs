using FluentValidation;
using AuthService.Application.Common.Validation;

namespace AuthService.Application.Requests.Auth.Validators;

public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidator()
    {
        RuleFor(x => x.CurrentPassword)
            .MatchPassword();
            
        RuleFor(x => x.NewPassword)
            .MatchPassword();
    }
}