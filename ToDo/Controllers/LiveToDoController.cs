using Microsoft.AspNetCore.Mvc;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiveToDoController : ControllerBase
    {
        private readonly HttpClient httpClient;
        Uri baseAddress = new Uri("https://jsonplaceholder.typicode.com/todos");

        public LiveToDoController()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public ActionResult Read()
        {
            HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                return Ok(data);
            }
            return BadRequest();
        }
    }
}
