using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.RequestsToYa;

namespace WebApplication2.Controllers
{
    [Route("[controller]/[action]")]
    public class Light : ControllerBase
    {
        
        string token = "";
        
        [HttpPost]
        public async Task<string> SetSettings([FromQuery] string id, [FromQuery] int value, [FromQuery] string instance)
        {

            if (instance != "temperature_k" && instance != "brightness")
                return "Error";
            
            var request = new BodyRequest();
            dynamic state = new ExpandoObject();
            
            state.instance = instance;
            state.value = value;

            var type = "";
            if (instance == "brightness")
                type = "devices.capabilities.range";
            if (instance == "temperature_k")
                type = "devices.capabilities.color_setting";
            
            var action = new Action(type, state);
            var device = new Device(id, action);
            request.Devices.Add(device);

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", token);
            
            var response = await client.PostAsync("https://api.iot.yandex.net/v1.0/devices/actions", content);
            
            return await response.Content.ReadAsStringAsync();
        }
        
    }
}