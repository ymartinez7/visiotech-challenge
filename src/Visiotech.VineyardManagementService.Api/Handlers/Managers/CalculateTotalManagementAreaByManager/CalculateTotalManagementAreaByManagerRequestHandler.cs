using MediatR;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.CalculateTotalManagementAreaByManager;

namespace Visiotech.VineyardManagementService.Api.Handlers.Managers.CalculateTotalManagementAreaByManager
{
    public sealed class CalculateTotalManagementAreaByManagerRequestHandler(
        ICalculateTotalManagedAreaUseCase useCase,
        CalculateTotalManagementAreaByManagerPresenter presenter) 
        : IRequestHandler<CalculateTotalManagementAreaByManagerRequest, IWebApiPresenter>
    {
        private readonly ICalculateTotalManagedAreaUseCase _useCase = useCase;
        private readonly CalculateTotalManagementAreaByManagerPresenter _presenter = presenter;

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
