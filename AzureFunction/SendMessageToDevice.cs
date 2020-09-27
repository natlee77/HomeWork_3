using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.Azure.Devices;

namespace AzureFunction
{
    public static class SendMessageToDevice
    {
        private static readonly ServiceClient serviceClient =
            ServiceClient.CreateFromConnectionString(Environment.GetEnvironmentVariable("IotHubConnection")); 
            // access policy IoTHub -- tog från Azure Iothub och lägger i local.setting.json

        [FunctionName("SendMessageToDevice")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string targetDeviceId = req.Query["targetdeviceid"];
            string message = req.Query["message"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
           
            var data = JsonConvert.DeserializeObject<BodyMessageModel>(requestBody); //instället dynamic=skapa en model BodyMessgaeModel
            
            targetDeviceId = targetDeviceId ?? data?.TargetDeviceId;
            message = message ?? data.Message;


             await DeviceService.SendMessageToDeviceAsync(serviceClient, targetDeviceId, message);
            

            return new OkResult(); //skicka tillbacka 200 ok
        }
    }
}
