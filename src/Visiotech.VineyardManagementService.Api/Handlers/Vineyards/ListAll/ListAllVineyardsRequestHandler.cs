using MediatR;
using Visiotech.VineyardManagementService.Application.UseCases.Vineyards.ListAll;

namespace Visiotech.VineyardManagementService.Api.Handlers.Vineyards.ListAll
{
    /// <summary>
    /// Handler of ListAllVineyardsRequest
    /// </summary>
    /// <param name="useCase">Use case</param>
    /// <param name="presenter">Presenter</param>
    public sealed class ListAllVineyardsRequestHandler(
        IListAllVineyardsUseCase useCase,
        ListAllVineyardsPresenter presenter) 
        : IRequestHandler<ListAllVineyardsRequest, IWebApiPresenter>
    {
        private readonly IListAllVineyardsUseCase _useCase = useCase;
        private readonly ListAllVineyardsPresenter _presenter = presenter;

        /// <summary>
        /// Executes the corresponding use case 
        /// </summary>
        /// <param name="request">Input</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Presenter</returns>
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
