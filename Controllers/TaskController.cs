using jayrideexam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace jayrideexam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        string geoLocationApiKey = "fa532d60824547c69eb0829c2b2aa998";

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }

        [HttpGet, Route("TaskOneGet")]
        public IActionResult TaskOneGet()
        {
            return Ok(new TaskOneResponse { name ="test", phone ="test" });
        }

        [HttpGet, Route("TaskTwoGet/{ipAddress}")]
        public  async Task <IActionResult> TaskTwoGet(String ipAddress)
        {
            try
            {
                HttpClient ClientFactory = new HttpClient();
                String requestLink = String.Format(@"https://api.geoapify.com/v1/ipinfo?ip={0}&apiKey={1}", ipAddress, geoLocationApiKey);

                var request = new HttpRequestMessage(HttpMethod.Get, requestLink);
                request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

                var response = await ClientFactory.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {

                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var result = await JsonSerializer.DeserializeAsync
                                <TaskTwoResponse>(responseStream);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch {
                return BadRequest();
            }
        }


        [HttpPost, Route("TaskThreeGet")]
        public async Task<IActionResult> TaskThreeGet(TaskThreeRequest model)
        {
            try
            {
                HttpClient ClientFactory = new HttpClient();
                String requestLink = String.Format(@"https://jayridechallengeapi.azurewebsites.net/api/QuoteRequest");

                var request = new HttpRequestMessage(HttpMethod.Get, requestLink);

                var response = await ClientFactory.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var result = await JsonSerializer.DeserializeAsync
                                <TaskThreeResponse>(responseStream);

                    var list = result.listings.Where(x => x.vehicleType.maxPassengers >= model.noOfPassanger)
                        .ToList();

                    var finalList = list.Select(y => new {
                        PricePerPassenger = y.pricePerPassenger,
                        TotalPrice = y.pricePerPassenger * model.noOfPassanger,
                        Name = y.name,
                        VehicleType = y.vehicleType
                    }).OrderByDescending(x => x.TotalPrice);
                    return Ok(finalList);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch {

                return BadRequest();
            }
            

        }
    }
}
