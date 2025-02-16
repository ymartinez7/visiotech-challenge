using MediatR;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllIds;

namespace Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllIds
{
    public sealed class ListAllManagerIdsRequestHandler(
        IListAllManagerIdsIUseCase useCase,
        ListAllManagerIdsPresenter presenter) 
        : IRequestHandler<ListAllManagerIdsRequest, IWebApiPresenter>
    {
        private readonly IListAllManagerIdsIUseCase _useCase = useCase;
        private readonly ListAllManagerIdsPresenter _presenter = presenter;

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
