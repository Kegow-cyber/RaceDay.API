using Microsoft.AspNetCore.Mvc;
using RaceDay.MVC.Models;
using System.Text.Json;

namespace RaceDay.MVC.Controllers
{
    public class EventsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBase = "http://localhost:5195";

        public EventsController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("RaceDayAPI");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{_apiBase}/api/Events");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = $"API returned {response.StatusCode}";
                return View(new List<EventViewModel>());
            }
            var json = await response.Content.ReadAsStringAsync();
            var events = JsonSerializer.Deserialize<List<EventViewModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return View(events);
        }
    }
}