namespace RandomStuff;

class Program
{
    static void Main(string[] args)
    {
        //getF(-30);
        //AddAndMultiply(1,1,1); 
        //ElemantaryOperations(20, 0);
        IsResultSame(2,2);
    }
    
    static void AddAndMultiply(int x, int xx, int xxx){
      Console.WriteLine((x + xx) * xxx);
    }
    
    static void getF(int x){
      if (x < -273.15) Console.WriteLine("Temperature below absolute zero!");
      Console.WriteLine(fahrenheitToC(x));
    }
    
    static double fahrenheitToC(int x){
      return x * 1.8 + 32;
    }

    static void ElemantaryOperations(int x, int xx){
      List<int> list = new List<int>();
      list.Add(x + xx);
      list.Add(x - xx);
      list.Add(x * xx);
      if (x != 0 && xx != 0){
        list.Add(x / xx);
      }
      Console.WriteLine(string.Join(", ", list));
    }

    static void IsResultSame(int x, int xx){
      if (x + xx == x * x ){
        Console.WriteLine("True");
      }
      else
      {
          Console.WriteLine("False");
      }
    }
    
    static int ModuloOperations(int a, int b, int c) => ((a % b) % c);

    static double CubeOf(double x) => x * x * x;

    string SwapTwoNumbers(int x, int y)
    {
      int temp = x;
      x = y;
      y = temp;
      return $"{x}, {y}";
    }


}
