using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Q42;
using Q42.HueApi.Converters;
using Q42.HueApi.Models;

namespace Test_Hue_Light_Control
{
    class Program
    {
        static void Main(string[] args)
        {
            HueControlAsync();
            Console.Read();

        }

        public static async Task HueControlAsync()
        {
            IBridgeLocator loca = new HttpBridgeLocator();

            var bridgeIPs = await loca.LocateBridgesAsync(TimeSpan.FromSeconds(5)); // Locate bridges

            Q42.HueApi.Models.Bridge.LocatedBridge hachi = new Q42.HueApi.Models.Bridge.LocatedBridge();

            foreach (var item in bridgeIPs)
            {
                hachi = item; // Control most recent bridge found.
                Console.WriteLine(item + ": " + item.IpAddress);
            }
            Console.WriteLine(hachi.IpAddress + " Controlling! (hopefully) ID: " + hachi.BridgeId );

            ILocalHueClient client = new LocalHueClient(hachi.IpAddress);
            client.Initialize("appkey");

            var command1 = new LightCommand();
            command1.On = false;
            client.SendCommandAsync(command1);
            Console.WriteLine("Sent~");
        }
    }
}
