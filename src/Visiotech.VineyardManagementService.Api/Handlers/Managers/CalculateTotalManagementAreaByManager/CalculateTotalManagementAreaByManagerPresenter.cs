using Microsoft.AspNetCore.Mvc;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.CalculateTotalManagementAreaByManager;

namespace Visiotech.VineyardManagementService.Api.Handlers.Managers.CalculateTotalManagementAreaByManager
{
    public sealed class CalculateTotalManagementAreaByManagerPresenter 
        : IWebApiPresenter, ICalculateTotalManagedAreaOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(CalculateTotalManagedAreaOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            if (!output.Areas.Any())
            {
                ActionResult = new NoContentResult();
                return;
            }

            ActionResult = new OkObjectResult(output.Areas);
        }
    }
}
