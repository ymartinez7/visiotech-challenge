using MediatR;

namespace Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllTaxNumbers
{
    public sealed class ListAllManagerTaxNumberRequest(bool sorted) : IRequest<IWebApiPresenter>
    {
        public bool Sorted { get; private set; } = sorted;
    }
}
