using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using VehicleIncServiceLibrary;

namespace VehicleIncConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(VehicleService));
            try
            {
                host.Open();
                PrintServiceInfo(host);

                Console.ReadLine();
                host.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                host.Abort();
            }
        }

        static void PrintServiceInfo(ServiceHost host)
        {
            Console.WriteLine("{0} Up and running with these endpoints:",
                host.Description.ServiceType);

            foreach (ServiceEndpoint sep in host.Description.Endpoints)
                Console.WriteLine(sep.Address);
        }
    }
}
