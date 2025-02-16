using Microsoft.AspNetCore.Mvc;
using Visiotech.VineyardManagementService.Application.UseCases.Managers.ListAllIds;

namespace Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllIds
{
    /// <summary>
    /// Presenter
    /// </summary>
    public sealed class ListAllManagerIdsPresenter 
        : IWebApiPresenter, IListAllManagerIdsOutputPort
    {
        public IActionResult ActionResult { get; private set; }

        public void StandardHandle(ListAllManagerIdsOutput list)
        {
            ArgumentNullException.ThrowIfNull(list);

            if (!list.ManagerIdsList.Any())
            {
                ActionResult = new NoContentResult();
                return;
            }

            List<ListAllManagerIdsResponse> managerIds = [];

            foreach (var managerId in list.ManagerIdsList)
            {
                managerIds.Add(new(managerId.Id, managerId.Name));
            }

            ActionResult = new OkObjectResult(managerIds);
        }
    }
}
