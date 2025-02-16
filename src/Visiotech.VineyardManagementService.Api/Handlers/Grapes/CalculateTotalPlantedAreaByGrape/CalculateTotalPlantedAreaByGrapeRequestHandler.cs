using MediatR;
using Visiotech.VineyardManagementService.Application.UseCases.Grapes.CalculateTotalPlantedAreaByGrape;

namespace Visiotech.VineyardManagementService.Api.Handlers.Grapes.CalculateTotalPlantedAreaByGrape
{
    /// <summary>
    /// Handler of CalculateTotalPlantedAreaByGrapeRequest
    /// </summary>
    /// <param name="useCase">Use case</param>
    /// <param name="presenter">Presenter</param>
    public sealed class CalculateTotalPlantedAreaByGrapeRequestHandler(
        ICalculateTotalPlantedAreaByGrapeUseCase useCase,
        CalculateTotalPlantedAreaByGrapePresenter presenter) 
        : IRequestHandler<CalculateTotalPlantedAreaByGrapeRequest, IWebApiPresenter>
    {
        private readonly ICalculateTotalPlantedAreaByGrapeUseCase _useCase = useCase;
        private readonly CalculateTotalPlantedAreaByGrapePresenter _presenter = presenter;

        /// <summary>
        /// Executes the corresponding use case 
        /// </summary>
        /// <param name="request">Input</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Presenter</returns>
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
