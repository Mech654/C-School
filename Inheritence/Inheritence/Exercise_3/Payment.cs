using System;

namespace Inheritence.Exercise_3
{
    public abstract class Payment
    {
        public abstract float Amount { get; set; }
        public abstract string Currency { get; set; }

        public virtual void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Processing payment...");
        }
    }
}