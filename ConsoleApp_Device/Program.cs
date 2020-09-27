using System;
using System.Threading.Tasks;
using ClassLibrary.Models;
using ClassLibrary.Services;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;

namespace ConsoleApp_Device
{
    class Program
    {
        private static readonly string _conn = "";


        
        private static readonly DeviceClient deviceClient = DeviceClient.
       CreateFromConnectionString(_conn, TransportType.Mqtt);


        static void Main(string[] args)
        {
            DeviceService.SendMessageAsync(deviceClient).GetAwaiter();
        }




    }
}
