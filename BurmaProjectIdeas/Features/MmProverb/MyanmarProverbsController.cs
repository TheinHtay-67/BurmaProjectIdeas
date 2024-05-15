using BurmaProjectIdeas.Commons;
using BurmaProjectIdeas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BurmaProjectIdeas.Features.MmProverb
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyanmarProverbsController : ControllerBase
    {
        private readonly Common _common;

        public MyanmarProverbsController()
        {
            _common = new Common();
        }

        private async Task<MMProverbModel> GetDataAsync()
        {
            var model = await _common.GetDataAsync<MMProverbModel>("MyanmarProverbs_Data.json");
            return model;
        }

        [HttpGet("title")]
        public async Task<IActionResult> Titles()
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbsTitle);
        }

        [HttpGet("subtitle/{titleId}")]
        public async Task<IActionResult> GetSubtitleById(int titleId)
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbs
                            .Where(x => x.TitleId == titleId)
                            .Select(x => new { x.ProverbId, x.ProverbName })
                            .ToList());
        }

        [HttpGet("mmproverbs/{titleId}/{proverbId}")]
        public async Task<IActionResult> Proverbs(int titleId, int proverbId)
        {
            var model = await GetDataAsync();
            return Ok(model.Tbl_MMProverbs.Where(x => x.TitleId == titleId && x.ProverbId == proverbId).FirstOrDefault());
        }
    }
}
