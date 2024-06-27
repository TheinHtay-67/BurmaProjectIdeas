using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BurmaProjectIdeas.Models;
using BurmaProjectIdeas.Commons;

namespace BurmaProjectIdeas.Features.LatHtaukBayDin
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatHtaukBayDinController : ControllerBase
    {
        private readonly Common _common;

        public LatHtaukBayDinController()
        {
            _common = new Common();
        }

        private async Task<LatHtaukBayDinDto> GetDataAsync()
        {
            //string basePath = AppDomain.CurrentDomain.BaseDirectory; // Get the base directory of the application
            //string filePath = Path.Combine(basePath, "Datas", "LatHtaukBayDin.json"); // Combine base directory with relative path to the json file

            //string jsonStr = await System.IO.File.ReadAllTextAsync(filePath); // Read the JSON file asynchronously
            //var model = JsonConvert.DeserializeObject<LatHtaukBayDinDto>(jsonStr);
            //return model;
            var model = await _common.GetDataAsync<LatHtaukBayDinDto>("LatHtaukBayDin.json");
            return model;
        }

        [HttpGet("questions")]
        public async Task<IActionResult> QuestionsAsync()
        {
            var model = await GetDataAsync();
            return Ok(model.questions.ToList());
        }

        [HttpGet("numberlist")]
        public async Task<IActionResult> NumberListAsync()
        {
            var model = await GetDataAsync();
            return Ok(model.numberList);
        }

        [HttpGet("{questionNo}/{no}")]
        public async Task<IActionResult> AnswersAsync(int questionNo, int no)
        {
            var model = await GetDataAsync();
            return Ok(model.answers.FirstOrDefault(x => x.questionNo == questionNo && x.answerNo == no));
        }
    }
}
