using MediatR;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllTaxNumbers;

namespace Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllTaxNumbers
{
    /// <summary>
    /// Handler of ListAllManagerTaxNumberRequest
    /// </summary>
    /// <param name="useCase">Use case</param>
    /// <param name="presenter">Presenter</param>
    public sealed class ListAllManagerTaxNumberRequestHandler(
        IListAllManagerTaxNumberUseCase useCase,
        ListAllManagerTaxNumberPresenter presenter) 
        : IRequestHandler<ListAllManagerTaxNumberRequest, IWebApiPresenter>
    {
        private readonly IListAllManagerTaxNumberUseCase _useCase = useCase;
        private readonly ListAllManagerTaxNumberPresenter _presenter = presenter;

        /// <summary>
        /// Executes the corresponding use case 
        /// </summary>
        /// <param name="request">Input</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Presenter</returns>
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
