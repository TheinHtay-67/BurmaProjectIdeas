using BurmaProjectIdeas.Models;
using Newtonsoft.Json;

namespace BurmaProjectIdeas.Commons
{
    public class Common
    {
        public static string birdRootPath { get; } = "https://github.com/sannlynnhtun-coding/Birds/tree/main";

        public async Task<T> GetDataAsync<T>(string fileName)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory; // Get the base directory of the application
            string filePath = Path.Combine(basePath, "Datas", fileName); // Combine base directory with relative path to the json file

            string jsonStr = await System.IO.File.ReadAllTextAsync(filePath); // Read the JSON file asynchronously
            var model = JsonConvert.DeserializeObject<T>(jsonStr);
            return model;
        }

        private string AddRootPath(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                return imagePath;
            }
            return birdRootPath + imagePath;
        }
    }
}
