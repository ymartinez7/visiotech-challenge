using MediatR;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllTaxNumbers;

namespace Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllTaxNumbers
{
    public sealed class ListAllManagerTaxNumberRequestHandler(
        IListAllManagerTaxNumberUseCase useCase,
        ListAllManagerTaxNumberPresenter presenter) 
        : IRequestHandler<ListAllManagerTaxNumberRequest, IWebApiPresenter>
    {
        private readonly IListAllManagerTaxNumberUseCase _useCase = useCase;
        private readonly ListAllManagerTaxNumberPresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(
            ListAllManagerTaxNumberRequest request, 
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new ListAllManagerTaxNumbersInput(request.Sorted));
            return _presenter;
        }
    }
}
