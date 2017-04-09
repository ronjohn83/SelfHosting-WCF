using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using CalcServiceLibrary;

namespace SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceHost2 = new ServiceHost(typeof(CalcServiceLibrary.CalcService1));
            ServiceEndpoint basicHttpEndPoint2 = serviceHost2.AddServiceEndpoint(
                typeof(CalcServiceLibrary.ICalcService),
                new BasicHttpBinding(),
                 "http://localhost:8081/CalcService");

    

            using (var serviceHost = new ServiceHost(typeof(Exercise_2.MathServiceLibrary)))
            {
                ServiceEndpoint basicHttpEndPoint1 = serviceHost.AddServiceEndpoint(
                    typeof(Exercise_2.IMathServiceLibrary),
                    new BasicHttpBinding(),
                    "http://localhost:8082/MathService");

                serviceHost.Open();
                serviceHost2.Open();

                Console.WriteLine("Your WCF service is running.");
                Console.WriteLine("Your WCF Math service is running and is listening on below endpoints:");
                Console.WriteLine("{0} ({1})", basicHttpEndPoint1.Address.ToString(), basicHttpEndPoint1.Binding.Name);
                Console.WriteLine();

                foreach (ServiceEndpoint endpoint in serviceHost.Description.Endpoints)
                {
                    Console.WriteLine("Address : {0} Binding Name : {1}",
                        endpoint.Address.ToString(), endpoint.Binding.Name);

                }
                foreach (ServiceEndpoint endpoint in serviceHost2.Description.Endpoints)
                {
                    Console.WriteLine("Address : {0} Binding Name : {1}",
                        endpoint.Address.ToString(), endpoint.Binding.Name);

                }
                Console.WriteLine();
                Console.WriteLine("Press any key to stop your WCF Math service.");
                Console.ReadKey();

               
                serviceHost.Close();
                serviceHost2.Close();
            }

      
        }
    }
}
