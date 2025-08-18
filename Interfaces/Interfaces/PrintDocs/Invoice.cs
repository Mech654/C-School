namespace Interfaces.Interfaces;

public class Invoice : IPrintable
{
    public void Print()
    {
        // Logic to print the invoice
        Console.WriteLine("Printing invoice...");
    }
}
