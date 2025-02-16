using MediatR;
using Visiotech.VineyardManagementService.Application.UseCases.Vineyards.ListAll;

namespace Visiotech.VineyardManagementService.Api.Handlers.Vineyards.ListAll
{
    public sealed class ListAllVineyardsRequestHandler(
        IListAllVineyardsUseCase useCase,
        ListAllVineyardsPresenter presenter) 
        : IRequestHandler<ListAllVineyardsRequest, IWebApiPresenter>
    {
        private readonly IListAllVineyardsUseCase _useCase = useCase;
        private readonly ListAllVineyardsPresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(
            ListAllVineyardsRequest request, 
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new ListAllVineyardsInput());
            return _presenter;
        }
    }
}
