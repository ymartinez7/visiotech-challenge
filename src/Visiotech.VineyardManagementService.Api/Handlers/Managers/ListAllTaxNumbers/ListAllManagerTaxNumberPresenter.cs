using Microsoft.AspNetCore.Mvc;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllTaxNumbers;

namespace Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllTaxNumbers
{
    public sealed class ListAllManagerTaxNumberPresenter 
        : IWebApiPresenter, IListAllManagerTaxNumbersOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ListAllManagerTaxNumbersOutput list)
        {
            ArgumentNullException.ThrowIfNull(list);

            if (!list.ManagerTaxNumbersList.Any())
            {
                ActionResult = new NoContentResult();
                return;
            }

            ActionResult = new OkObjectResult(list.ManagerTaxNumbersList);
        }
    }
}
