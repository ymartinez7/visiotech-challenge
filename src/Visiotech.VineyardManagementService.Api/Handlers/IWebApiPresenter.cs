using Microsoft.AspNetCore.Mvc;

namespace Visiotech.VineyardManagementService.Api.Handlers
{
    /// <summary>
    /// Interface for all presenters
    /// </summary>
    public interface IWebApiPresenter
    {
        IActionResult ActionResult { get; }
    }
}
