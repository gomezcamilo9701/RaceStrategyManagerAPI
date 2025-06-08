using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using RaceStrategyManager.Application.Contract;
using RaceStrategyManager.Application.Dto;

namespace RaceStrategyManagerAPI.Controllers
{
    [ApiController]
    [Route("api/pilot")]
    public class PilotController : ControllerBase
    {
        private readonly IPilotService _pilotService;

        public PilotController(IPilotService pilotService)
        {
            _pilotService = pilotService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<List<PilotDto>> GetAllPilotsAsync() => await _pilotService.GetAllPilotsAsync();
    }
}
