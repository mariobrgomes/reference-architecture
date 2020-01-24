using MediatR;
using RIFS.Core.Application.Outputs;

namespace Application.CreateCheckingAccount
{
    public class CreateCheckingAccountInput : IRequest<Output>
    {
        public CreateCheckingAccountInput(int tradingAccount, int brand, string fullName, string phoneNumber)
        {
            TradingAccount = tradingAccount;
            Brand = brand;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public int TradingAccount { get; set; }
        public int Brand { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
