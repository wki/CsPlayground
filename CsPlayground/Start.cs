using Microsoft.Practices.Unity;
using System;

namespace CsPlayground
{
    public static class Start
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Main start");

            var container = new UnityContainer();
            Bootstrapper.Install(container); // find a way to do this by convention

            var adder = container.Resolve<IAdder>();

            Console.WriteLine("Add1(3) = {0}", adder.Add1(3));

            Console.WriteLine("Main end");
        }
    }
}
