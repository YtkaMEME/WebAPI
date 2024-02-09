using System.Collections.Generic;
using System.Dynamic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WebApplication2.RequestsToYa;
using Action = WebApplication2.RequestsToYa.Action;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ForAll : ControllerBase
    {

        private readonly string _token = "";
        
        [HttpGet]
        public async Task<JsonResult> GetAllInfo()
        {
            var httpClient = new HttpClient();
            
            httpClient.DefaultRequestHeaders.Add("Authorization", _token);

            var stream = await httpClient.GetStringAsync("https://api.iot.yandex.net/v1.0/user/info");

            var info = JsonConvert.DeserializeObject<InfoJson>(stream);

            var allDevises = new List<OnlyNeedInfo>();

            foreach (var devise in info.devices)
            {
                var deviseInfo = new OnlyNeedInfo();
                deviseInfo.id = devise.id;
                deviseInfo.type = devise.type;
                deviseInfo.name = devise.name;
                allDevises.Add(deviseInfo);
            }

            return new JsonResult(allDevises);
        }

        [HttpGet]
        public async Task<string> GetDeviceState([FromQuery]string id)
        {
            var httpClient = new HttpClient();
            
            httpClient.DefaultRequestHeaders.Add("Authorization", _token);

            var info = await httpClient.GetStringAsync($"https://api.iot.yandex.net/v1.0/devices/{id}");
            
            return info;  
        }
        
        [HttpPost]
        public async Task<string> turnOffOn([FromQuery]bool value, [FromQuery]string id)
        {
            var request = new BodyRequest();
            
            dynamic state = new ExpandoObject();
            state.Instance = "on";
            state.value = value;
            
            var action = new Action("devices.capabilities.on_off", state);
            var device = new Device(id, action);
            request.Devices.Add(device);

            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", _token);
            
            var response = await client.PostAsync("https://api.iot.yandex.net/v1.0/devices/actions", content);
            
            return await response.Content.ReadAsStringAsync();
        }
        
    }
}