using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WinkelServiceLibrary2;

namespace WinkelHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WinkelService)))
            {
                host.Open();
                Console.WriteLine("ok");
                Console.Read();
            }
        }
    }
}
