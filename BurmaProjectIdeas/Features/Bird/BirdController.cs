using BurmaProjectIdeas.Commons;
using BurmaProjectIdeas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurmaProjectIdeas.Features.Bird
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdController : ControllerBase
    {
        private readonly Common _common;
        private readonly string rootPath = "https://github.com/sannlynnhtun-coding/Birds/tree/main";
        public BirdController()
        {
            _common = new Common();
        }

        private async Task<BirdDto> GetDataAsync()
        {
            var model = await _common.GetDataAsync<BirdDto>("Birds.json");

            // Get the base URL from the configuration or construct it
            var request = HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
            foreach (var bird in model.Tbl_Bird)
            {
                // Construct the relative image path URL
                string relativeImagePath = Path.Combine("Images", "Birds", bird.ImagePath);
                bird.ImagePath = new Uri(new Uri(baseUrl), relativeImagePath).ToString();
            }

            return model;
        }

        [HttpGet("birds")]
        public async Task<IActionResult> GridsAsync()
        {
            var model = await GetDataAsync();
            if (model is null)
            {
                return NotFound("No Data Found");
            }

            #region test
            //foreach (var bird in model.Tbl_Bird)
            //{
            //    //bird.ImagePath = Path.Combine(rootPath, bird.ImagePath);

            //    string basePath = AppDomain.CurrentDomain.BaseDirectory; // Get the base directory of the application
            //    string filePath = Path.Combine(basePath, "Images", "Birds", bird.ImagePath);
            //    bird.ImagePath = filePath;

            //    //bird.ImagePath = $"{rootPath.TrimEnd('/')}/{bird.ImagePath.TrimStart('/')}";
            //}
            #endregion

            return Ok(model.Tbl_Bird.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GridAsync(int id)
        {
            var model = await GetDataAsync();
            if (model is null)
            {
                return NotFound("No Data Found");
            }

            return Ok(model.Tbl_Bird.FirstOrDefault(x => x.Id == id));
        }
    }
}
