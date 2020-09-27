using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using ClassLibrary.Models;


namespace ClassLibrary.Services
{
    public static class DeviceService
    {
        private static readonly Random rnd = new Random();

        
        public static async Task SendMessageAsync(DeviceClient deviceClient)
        {
            
            while (true)
            {
                var data = new TemperatureCatalog()
                {
                    Temperature = rnd.Next(-20, 30),
                    Humidity = rnd.Next(30, 60)
                };

                // mdl ska konvertera i json format{"temperature":20, "humidity": 44}
                var json = JsonConvert.SerializeObject(data);

                //skicka mdl=payload/ Message-från  Microsoft.Azure.Devices.Client;
                //Encoding-formatera
                var payload = new Message(Encoding.UTF8.GetBytes(json));// Bytes 0 eller 1
                await deviceClient.SendEventAsync(payload);//använda message/ async = await /det skicka mdl i molnet

                Console.WriteLine($"Message sent : {json}");
                await Task.Delay(60 * 1000);
            }
        }
    }
}
