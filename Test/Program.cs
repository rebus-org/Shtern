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
            var answer = Options.Prompt("Which Javascript transpizzle would you like to use to mangle your shizzle?",
                new[]
                {
                    new {Id = "babel", Name = "Babel"},
                    new {Id = "ts", Name = "TypeScript"},
                    new {Id = "whatever", Name = "Whateverleavemyjavascriptalone!"},
                });

            Console.WriteLine($"Selected option: {answer}");
        }

        static void TestPassword()
        {
            var password = Password.ReadLine(prompt: "Your password, please > ");

            Console.WriteLine($"Here it is: {password}");
        }
    }
}
