using System;

namespace ServerCSharp
{
    internal class MethodInvoker
    {
        private Func<object> p;

        public MethodInvoker(Func<object> p)
        {
            this.p = p;
        }
    }
}