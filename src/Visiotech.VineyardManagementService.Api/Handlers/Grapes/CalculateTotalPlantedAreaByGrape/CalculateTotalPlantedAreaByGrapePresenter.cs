using Microsoft.AspNetCore.Mvc;
using Visiotech.VineyardManagementService.Application.UseCases.Grapes.CalculateTotalPlantedAreaByGrape;

namespace Visiotech.VineyardManagementService.Api.Handlers.Grapes.CalculateTotalPlantedAreaByGrape
{
    /// <summary>
    /// Presenter
    /// </summary>
    public sealed class CalculateTotalPlantedAreaByGrapePresenter 
        : IWebApiPresenter, ICalculateTotalPlantedAreaByGrapeOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(CalculateTotalPlantedAreaByGrapeOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);
            
            if (!output.CalculatedAreas.Any())
            {
                ActionResult = new NoContentResult();
                return;
            }

            ActionResult = new OkObjectResult(output.CalculatedAreas);
        }
    }
}
