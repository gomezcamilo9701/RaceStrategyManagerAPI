using Microsoft.AspNetCore.Mvc;
using RaceStrategyManager.Application.Contract;
using RaceStrategyManager.Application.Dto;

namespace RaceStrategyManagerAPI.Controllers
{
    [ApiController]
    [Route("/api/strategy")]
    public class StrategyController : Controller
    {
        private IStrategyService _strategyService;

        public StrategyController(IStrategyService strategyService)
        {
            _strategyService = strategyService;
        }

        [HttpGet]
        [Route("optimal")]
        public async Task<List<StrategyDto>> GetOptimalStrategy(int maxLaps, int pilotId) => await _strategyService.GetOptimalStrategy(maxLaps, pilotId);
    }
}
