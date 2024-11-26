using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Counting numbers from 1 to 100,000...");

        for (int i = 1; i <= 100000; i++)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Finished counting!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
