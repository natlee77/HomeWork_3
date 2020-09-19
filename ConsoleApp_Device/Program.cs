using System;
using System.Threading.Tasks;

namespace ConsoleApp_Device
{
    class Program
    {
        static void Main(string[] args)// sync  huvud tråd //aldrig await resultat
        { 
              DoWork());  
        }
        
        static  void  DoWork()  //back liggande system
        {
            Task.Run(() => DoWorkAsync());
        } 
         


        static async Task  DoWorkAsync ()
        {
            var result = await Task.Run(() => { return 1; });// retunera nån

            Console.WriteLine("{result}");
        }  
        
    }
}
