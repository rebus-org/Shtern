using System;
using Shtern;

namespace Test
{
    class Program
    {
        static void Main()
        {
            TestOptions();

            //            TestPassword();
        }

        static void TestOptions()
        {
            Console.WriteLine("Which Javascrizzle transpizzle would you like to use to compizzle your shizzle?");

            var answer = Options.Select(new[]
                {
                    new {Id = "babel", Name = "Babel"},
                    new {Id = "ts", Name = "TypeScript"},
                    new {Id = "whatever", Name = "Whateverleavemyjavascriptalone!"},
                },
                arrow: " > ");

            Console.WriteLine($"Selected option: {answer}");
        }

        static void TestPassword()
        {
            var password = Password.ReadLine(prompt: "Your password, please > ");

            Console.WriteLine($"Here it is: {password}");
        }
    }
}
