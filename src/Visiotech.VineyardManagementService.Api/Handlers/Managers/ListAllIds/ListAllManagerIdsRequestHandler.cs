using MediatR;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllIds;

namespace Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllIds
{
    /// <summary>
    /// Handler of ListAllManagerIdsRequest
    /// </summary>
    /// <param name="useCase">Use case</param>
    /// <param name="presenter">Presenter</param>
    public sealed class ListAllManagerIdsRequestHandler(
        IListAllManagerIdsUseCase useCase,
        ListAllManagerIdsPresenter presenter) 
        : IRequestHandler<ListAllManagerIdsRequest, IWebApiPresenter>
    {
        private readonly IListAllManagerIdsUseCase _useCase = useCase;
        private readonly ListAllManagerIdsPresenter _presenter = presenter;

        /// <summary>
        /// Executes the corresponding use case 
        /// </summary>
        /// <param name="request">Input</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Presenter</returns>
        public async Task<IWebApiPresenter> Handle(
            ListAllManagerIdsRequest request, 
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new ListAllManagerIdsInput());
            return _presenter;
        }
    }
}
