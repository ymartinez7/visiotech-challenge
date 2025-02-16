using MediatR;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.CalculateTotalManagementAreaByManager;

namespace Visiotech.VineyardManagementService.Api.Handlers.Managers.CalculateTotalManagementAreaByManager
{
    /// <summary>
    /// Handler of CalculateTotalManagementAreaByManagerRequest
    /// </summary>
    /// <param name="useCase">Use case</param>
    /// <param name="presenter">Presenter</param>
    public sealed class CalculateTotalManagementAreaByManagerRequestHandler(
        ICalculateTotalManagedAreaUseCase useCase,
        CalculateTotalManagementAreaByManagerPresenter presenter) 
        : IRequestHandler<CalculateTotalManagementAreaByManagerRequest, IWebApiPresenter>
    {
        private readonly ICalculateTotalManagedAreaUseCase _useCase = useCase;
        private readonly CalculateTotalManagementAreaByManagerPresenter _presenter = presenter;

        /// <summary>
        /// Executes the corresponding use case 
        /// </summary>
        /// <param name="request">Input</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Presenter</returns>
        public async Task<IWebApiPresenter> Handle(
            CalculateTotalManagementAreaByManagerRequest request, 
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new CalculateTotalManagedAreaInput());
            return _presenter;
        }
    }
}
