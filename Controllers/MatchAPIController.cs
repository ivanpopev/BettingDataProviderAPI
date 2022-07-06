using BettingDataProvider.Context;
using BettingDataProvider.Models;
using BettingDataProvider.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BettingDataProvider.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MatchAPIController : ControllerBase
    {
        private readonly MatchAPIService _service;
        public MatchAPIController(MatchAPIService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<MatchResult> GetMatch(int id)
        {
            try
            {
                return await _service.GetMatch(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet]
        public async Task<List<MatchResult>> GetMatches()
        {
            try
            {
                return await _service.GetUpcomingMatches();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}