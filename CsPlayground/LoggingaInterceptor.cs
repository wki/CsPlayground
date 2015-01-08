using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CsPlayground
{
    public class LoggingInterceptor: IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Log("Before executing {0}({1})", invocation.Method.Name, String.Join(", ", invocation.Arguments));
            invocation.Proceed();
            Log("Finished {0}, got {1}", invocation.Method.Name, invocation.ReturnValue ?? "NULL");
        }

        private void Log(string message, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format(message, args));
            Console.ResetColor();
        }
    }
}
