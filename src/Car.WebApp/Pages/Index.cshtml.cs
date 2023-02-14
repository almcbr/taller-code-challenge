using Car.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Web;

namespace Car.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private const string uriAPI = "http://localhost:5262/Cars";
        private readonly Uri baseUri = new(uriAPI);
        public string Message { get; set; }
        public IndexModel()
        {
          
        }

        public CarModel carModel { get; set; } = new();

        public void OnGet()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(uriAPI);
                if (response.Result.IsSuccessStatusCode)
                {
                    var tempResult = response.Result.Content.ReadAsStringAsync();
                    carModel.Cars = JsonConvert.DeserializeObject<List<Models.Car>>(tempResult.Result);
                }
            }
        }
        public void OnPostGuess()
        {
            using (var httpClient = new HttpClient())
            {
                var guessValue = Request.Form["guessValue"];
                var carId = Request.Form["item.Id"];
                Message = "";

                if (!string.IsNullOrEmpty(guessValue))
                {
                    var uri = new Uri(baseUri, $"cars/{carId}");
                    var response = httpClient.GetAsync(uri);
                    if (response.Result.IsSuccessStatusCode)
                    {
                        var tempResult = response.Result.Content.ReadAsStringAsync();
                        var cars = JsonConvert.DeserializeObject<Models.Car>(tempResult.Result);
                        if (cars != null)
                        {
                            var carPrice = cars.Price;
                            if (Math.Abs(carPrice - Decimal.Parse(guessValue)) <= 5000)
                                Message = "Great Job";
                        }
                    }
                }
                OnGet();
            }
        }
    }
}
