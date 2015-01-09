using Castle.Windsor;
using Castle.Windsor.Installer;
using System;

namespace CsPlayground
{
    public static class Start
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Main");

            var container = new WindsorContainer()
                .Install(FromAssembly.This());

            var adder = container.Resolve<IAdder>();

            adder.Add1(3);

            Console.WriteLine("Ending Main");
        }
    }
}
