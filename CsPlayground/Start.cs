
using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPlayground
{
    public static class Start
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting Main");

            var container = new WindsorContainer();
            container.Register(
                Component.For<IInterceptor>()
                    .ImplementedBy<LoggingInterceptor>()
                    .Named("logginginterceptor")
            );
            container.Register(
                Component.For<IAdder>()
                    .ImplementedBy<Adder>()
                    .Interceptors(InterceptorReference.ForKey("logginginterceptor")).Anywhere
            );
            var adder = container.Resolve<IAdder>();
            
            adder.Add1(3);

            Console.WriteLine("Ending Main");
        }
    }
}
