using Microsoft.AspNetCore.Mvc;
using Visiotech.VineyardManagementService.Application.UseCases.Vineyards.ListAll;

namespace Visiotech.VineyardManagementService.Api.Handlers.Vineyards.ListAll
{
    public sealed class ListAllVineyardsPresenter 
        : IWebApiPresenter, IListAllVineyardsOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ListAllVineyardsOutput output)
        {
            ArgumentNullException.ThrowIfNull(output);

            if (!output.Vineyards.Any())
            {
                ActionResult = new NoContentResult();
                return;
            }

            ActionResult = new OkObjectResult(output.Vineyards);
        }
    }
}
