using System;

namespace Inheritence.Exercise_3
{
    public class CreditCardPayment : Payment
    {
        public override float Amount { get; set; }
        public override string Currency { get; set; }

        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Processing Credit Card payment...");
        }
    }
}