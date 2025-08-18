namespace Interfaces.Interfaces;

public class Printer
{
    public void PrintDocuments(List<IPrintable> documents)
    {
        foreach (var document in documents)
        {
            document.Print();
        }
    }
}
