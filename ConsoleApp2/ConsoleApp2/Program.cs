namespace ConsoleApp2;

class Program
{
    static void Main(string[] args)
    {
        stacktest2();
        

    }

    private void stacktest1()
    {
        Human hm = new Human();
        hm.Name = "John";

        Human hm2 = hm;
        Console.WriteLine(hm.Name);
        Console.WriteLine(hm2.Name);
        
        hm.Name = "Jane";
        Console.WriteLine(hm2.Name);
    }

    static void stacktest2()
    {
        String str1 = "123123";
        String str2 = str1;
        Console.WriteLine(str1);
        Console.WriteLine(str2);

        str1 = "woaaa";
        Console.WriteLine(str2);
    }
}

class Human{
    
    public string Name { get; set; }

}
