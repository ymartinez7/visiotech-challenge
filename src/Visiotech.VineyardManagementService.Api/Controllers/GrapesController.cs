using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Visiotech.VineyardManagementService.Api.Handlers.Grapes.CalculateTotalPlantedAreaByGrape;

namespace Visiotech.VineyardManagementService.Api.Controllers
{
    /// <summary>
    /// Grapes controller
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="sender">Mediato</param>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class GrapesController(
        ILogger<GrapesController> logger,
        ISender sender) : ControllerBase
    {
        private readonly ILogger<GrapesController> _logger = logger;
        private readonly ISender _sender = sender;

        /// <summary>
        /// Calculate total planted area by grape
        /// </summary>
        /// <param name="request">Input</param>
        /// <returns>Dictionary of caculated areas</returns>
        [HttpPost("area")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Dictionary<string, int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CalculateTotalPlantedAreaByGrape([FromBody] CalculateTotalPlantedAreaByGrapeRequest request)
        {
            _logger.LogInformation("Request recieved in {Endpoint} at {UtcDateTime}",
                nameof(CalculateTotalPlantedAreaByGrape),
                DateTime.UtcNow);

            var presenter = await _sender.Send(request);
            return presenter.ActionResult;
        }
    }
}
