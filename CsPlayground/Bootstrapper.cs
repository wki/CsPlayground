using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;

namespace CsPlayground
{
    /// <summary>
    /// must be instantiated and called from startup
    /// </summary>
    public class Bootstrapper
    {
        static public void Install(IUnityContainer container)
        {
            Console.WriteLine("Installing Container");

            container
                .AddNewExtension<Interception>()
                .RegisterType<IAdder, Adder>(
                    new Interceptor<InterfaceInterceptor>(),
                    new InterceptionBehavior<LoggingInterceptor>("logging"));
        }
    }
}
