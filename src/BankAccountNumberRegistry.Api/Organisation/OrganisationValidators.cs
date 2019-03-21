namespace BankAccountNumberRegistry.Api.Organisation
{
    using System;
    using FluentValidation;

    public static class OrganisationValidators
    {
        public static IRuleBuilderOptions<T, Guid?> Required<T>(this IRuleBuilder<T, Guid?> ruleBuilder)
            => ruleBuilder
                .NotEmpty()
                .WithMessage("{PropertyName} is verplicht.");

        public static IRuleBuilderOptions<T, string> Required<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder
                .NotEmpty()
                .WithMessage("{PropertyName} is verplicht.");

        public static IRuleBuilderOptions<T, string> MaxLength<T>(this IRuleBuilder<T, string> ruleBuilder, int length)
            => ruleBuilder
                .Length(0, length)
                .WithMessage("{PropertyName} kan niet langer zijn dan {MaxLength}.");

        public static IRuleBuilderOptions<T, string> ValidOvoNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder
                .Must(property => property.ToUpperInvariant().StartsWith("OVO")) // TODO: Check if the last chars are digits
                .WithMessage("{PropertyName} moet een geldig OVO nummer zijn.");
    }
}
