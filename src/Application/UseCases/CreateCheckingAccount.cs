using Application.Boundaries.CreateCheckingAccount;
using Application.CreateCheckingAccount;
using MediatR;
using RIFS.Core.Application.Outputs;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public sealed class CreateCheckingAccount : IUseCase
    {
        public async Task<Output> Handle(CreateCheckingAccountInput request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
