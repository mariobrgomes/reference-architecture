using Application.CreateCheckingAccount;
using FluentValidation;

namespace Application.Boundaries.CreateCheckingAccount
{
    public sealed class CreateCheckingAccountInputValidation : AbstractValidator<CreateCheckingAccountInput>
    {
        public CreateCheckingAccountInputValidation()
        {
            ValidateTradingAccount();
        }

        private void ValidateTradingAccount()
        {
            RuleFor(c => c.TradingAccount)
                .GreaterThan(0).WithMessage("Trading account must be greater than zero.")
                .LessThan(10000).WithMessage("Trading account must be lesser than 10.000.");
        }
    }
}
