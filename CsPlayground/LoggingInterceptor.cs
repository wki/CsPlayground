using Microsoft.Practices.Unity.InterceptionExtension;
using System;

namespace CsPlayground
{
    public class LoggingInterceptor: IInterceptionBehavior
    {
        public System.Collections.Generic.IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Log("Before executing {0}({1})", input.MethodBase.Name, String.Join(", ", input.Arguments));
            var result = getNext()(input, getNext);
            Log("Finished {0}, got {1}", input.MethodBase.Name, result.ReturnValue ?? "NULL");

            return result;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        private void Log(string message, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format(message, args));
            Console.ResetColor();
        }
    }
}
