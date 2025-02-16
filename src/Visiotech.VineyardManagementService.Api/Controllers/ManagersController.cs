using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Visiotech.VineyardManagementService.Api.Handlers.Managers.CalculateTotalManagementAreaByManager;
using Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllIds;
using Visiotech.VineyardManagementService.Api.Handlers.Managers.ListAllTaxNumbers;

namespace Visiotech.VineyardManagementService.Api.Controllers
{
    /// <summary>
    /// Managers controller
    /// </summary>
    /// <param name="logger">Logger</param>
    /// <param name="sender">Mediato</param>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ManagersController(
        ILogger<ManagersController> logger,
        ISender sender) : ControllerBase
    {
        private readonly ILogger<ManagersController> _logger = logger;
        private readonly ISender _sender = sender;

        /// <summary>
        /// List all managers ids
        /// </summary>
        /// <returns>List of ids</returns>
        [HttpGet("ids")]
        [ProducesResponseType(typeof(IEnumerable<ListAllManagerIdsResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> ListAllManagersIds()
        {
            _logger.LogInformation("Request recieved in {Endpoint} at {UtcDateTime}",
                nameof(ListAllManagersIds),
                DateTime.UtcNow);

            var presenter = await _sender.Send(new ListAllManagerIdsRequest());
            return presenter.ActionResult;
        }

        /// <summary>
        /// List all manager tax numbers
        /// </summary>
        /// <param name="sorted">Is sorted by name</param>
        /// <returns></returns>
        [HttpGet("taxnumbers")]
        [ProducesResponseType(typeof(IEnumerable<ListAllManagerTaxNumberResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> ListAllManagerTaxNumbers([FromQuery] bool sorted)
        {
            _logger.LogInformation("Request recieved in {Endpoint} at {UtcDateTime}",
                nameof(ListAllManagerTaxNumbers),
                DateTime.UtcNow);

            var presenter = await _sender.Send(new ListAllManagerTaxNumberRequest(sorted));
            return presenter.ActionResult;
        }

        /// <summary>
        /// Calculate total management area by manager
        /// </summary>
        /// <param name="request">Input</param>
        /// <returns>Dictionary of caculated areas</returns>
        [HttpPost("totalarea")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Dictionary<string, int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CalculateTotalManagementAreaByManager([FromBody] CalculateTotalManagementAreaByManagerRequest request)
        {
            _logger.LogInformation("Request recieved in {Endpoint} at {UtcDateTime}",
                nameof(CalculateTotalManagementAreaByManager),
                DateTime.UtcNow);

            var presenter = await _sender.Send(request);
            return presenter.ActionResult;
        }
    }
}
