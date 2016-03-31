using System;
using Shtern;

namespace Test
{
    class Program
    {
        static void Main()
        {
            var password = Password.ReadLine(prompt: "Your password, please > ", mask: "");

            Console.WriteLine($"Here it is: {password}");
        }
    }
}
