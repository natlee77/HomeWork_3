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
        private static readonly string _conn = "HostName=ecwin20IoTHub.azure-devices.net;DeviceId=consoleapp;SharedAccessKey=3RSw06VBsoW/NBcIcqQ2tSm6tgWUoNDD+GxRHARsZ78=";


        
        private static readonly DeviceClient deviceClient = DeviceClient.
       CreateFromConnectionString(_conn, Microsoft.Azure.Devices.Client.TransportType.Mqtt);


        static void Main(string[] args)
        {
            DeviceService.SendMessageAsync(deviceClient).GetAwaiter();
            DeviceService.ReceiveMessageAsync(deviceClient).GetAwaiter();

            Console.ReadKey();
        }




    }
}
