using Application.CreateCheckingAccount;
using MediatR;
using RIFS.Core.Application.Outputs;

namespace Application.Boundaries.CreateCheckingAccount
{
    public interface IUseCase : IRequestHandler<CreateCheckingAccountInput, Output>
    {
    }
}
