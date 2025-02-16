using MediatR;
using Visiotech.VineyardManagementService.Application.UseCases.Grapes.CalculateTotalPlantedAreaByGrape;

namespace Visiotech.VineyardManagementService.Api.Handlers.Grapes.CalculateTotalPlantedAreaByGrape
{
    public sealed class CalculateTotalPlantedAreaByGrapeRequestHandler(
        ICalculateTotalPlantedAreaByGrapeUseCase useCase,
        CalculateTotalPlantedAreaByGrapePresenter presenter) 
        : IRequestHandler<CalculateTotalPlantedAreaByGrapeRequest, IWebApiPresenter>
    {
        private readonly ICalculateTotalPlantedAreaByGrapeUseCase _useCase = useCase;
        private readonly CalculateTotalPlantedAreaByGrapePresenter _presenter = presenter;

        public async Task<IWebApiPresenter> Handle(
            CalculateTotalPlantedAreaByGrapeRequest request, 
            CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            await _useCase.Execute(new CalculateTotalPlantedAreaByGrapeInput());
            return _presenter;
        }
    }
}
