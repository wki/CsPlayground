using Castle.Core;
using Castle.Core.Logging;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;

namespace CsPlayground
{
    /// <summary>
    /// Will be automatically called via .Install() by Windsor
    /// </summary>
    public class Bootstrapper: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Console.WriteLine("Installing Container");

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
        }
    }
}
