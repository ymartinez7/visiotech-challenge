using MediatR;

namespace Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllTaxNumbers
{
    /// <summary>
    /// Request
    /// </summary>
    /// <param name="sorted">If is sorted by manager name</param>
    public sealed class ListAllManagerTaxNumberRequest(bool sorted) : IRequest<IWebApiPresenter>
    {
        public bool Sorted { get; private set; } = sorted;
    }
}
