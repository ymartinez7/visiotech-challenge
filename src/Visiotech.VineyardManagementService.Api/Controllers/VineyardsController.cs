using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Visiotech.VineyardManagementService.Api.Handlers.Vineyards.ListAll;

namespace Visiotech.VineyardManagementService.Api.Controllers
{
    /// <summary>
    /// Vineyards controller
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="sender">Mediato</param>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class VineyardsController(
        ILogger<VineyardsController> logger,
        ISender sender) : ControllerBase
    {
        private readonly ILogger<VineyardsController> _logger = logger;
        private readonly ISender _sender = sender;

        /// <summary>
        /// List all managers by vineyard
        /// </summary>
        /// <returns>Dictionary of managers by vineyards</returns>
        [HttpGet("managers")]
        [ProducesResponseType(typeof(Dictionary<string, List<string>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> ListAllManagersByVineyard()
        {
            _logger.LogInformation("Request recieved in {Endpoint} at {UtcDateTime}",
                nameof(ListAllManagersByVineyard),
                DateTime.UtcNow);

            var presenter = await _sender.Send(new ListAllVineyardsRequest());
            return presenter.ActionResult;
        }
    }
}
