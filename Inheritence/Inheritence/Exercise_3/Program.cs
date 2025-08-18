using System;

namespace Inheritence.Exercise_3
{
    public class Program
    {
        public static void MainEx3(string[] args)
        {
            PayPalPayment paypal = new PayPalPayment();
            paypal.Amount = 100.50f;
            paypal.Currency = "USD";
            paypal.ProcessPayment((decimal)paypal.Amount);

            CreditCardPayment creditCard = new CreditCardPayment();
            creditCard.Amount = 250.75f;
            creditCard.Currency = "EUR";
            creditCard.ProcessPayment((decimal)creditCard.Amount);
        }
    }
}