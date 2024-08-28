using FluentValidation;

namespace AuthService.Application.Common.Validation;

public static class ValidationExtensions
{
    public static IRuleBuilderOptions<T, string> MatchPhoneNumber<T>(this IRuleBuilder<T, string> rule)
        => rule
            .NotNull()
            .NotEmpty().WithMessage("Phone number is required")
            .Matches(@"^\d{9,15}$").WithMessage("The phone number should consist of 9-15 digits");
    
    public static IRuleBuilderOptions<T, string> MatchPassword<T>(this IRuleBuilder<T, string> rule)
        => rule
            .NotNull()
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("The password should be at least 8 characters long.")
            .Matches(@"[A-Z]+").WithMessage("The password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("The password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("The password must contain at least one number.")
            .Matches(@"[\!\?\*\.]+").WithMessage("The password must contain at least special character (!? *.).");
    
    public static IRuleBuilderOptions<T, string> MatchName<T>(this IRuleBuilder<T, string> rule)
        => rule
            .Matches(@"^[A-Za-z]+(?:\\s[A-Za-z]+)*$")
            .WithMessage("The name can only consist of letters and spaces");
}