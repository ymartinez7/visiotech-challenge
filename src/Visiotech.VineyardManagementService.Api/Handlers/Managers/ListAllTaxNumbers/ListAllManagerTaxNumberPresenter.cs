using Microsoft.AspNetCore.Mvc;
using Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllIds;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllTaxNumbers;

namespace Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllTaxNumbers
{
    /// <summary>
    /// Presenter
    /// </summary>
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

            List<ListAllManagerTaxNumberResponse> managerTaxNumbers = [];

            foreach (var managerTaxNumber in list.ManagerTaxNumbersList)
            {
                managerTaxNumbers.Add(new(managerTaxNumber.TaxNumber.Value, managerTaxNumber.Name));
            }

            ActionResult = new OkObjectResult(managerTaxNumbers);
        }
    }
}
