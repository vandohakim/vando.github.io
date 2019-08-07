using System;

namespace ServerCSharp
{
    internal class invoke
    {
        private Func<object> p;

        public invoke(Func<object> p)
        {
            this.p = p;
        }
    }
}