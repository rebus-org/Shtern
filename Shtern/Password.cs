using System;
using System.Collections.Generic;
using System.Linq;

namespace Shtern
{
    /// <summary>
    /// Call <see cref="ReadLine"/> to read a password in from the command line
    /// </summary>
    public static class Password
    {
        /// <summary>
        /// Reads a line from the console, optionally outputting a mask character for each character entered.
        /// The mast character can be customized by setting <paramref name="mask"/> to something else.
        /// By default the mask character is an empty string because that is the most secure.
        /// Setting <paramref name="prompt"/> to something like "Please type your password > " provides an easy 
        /// way to have an inline prompt telling the user what to do
        /// </summary>
        public static string ReadLine(string mask = "", string prompt = null)
        {
            var enteredCharacters = new Stack<char>();

            if (prompt != null)
            {
                Console.Write(prompt);
            }

            while (true)
            {
                var consoleKeyInfo = Console.ReadKey(true);

                if (consoleKeyInfo.Key == ConsoleKey.Enter) break;

                if (consoleKeyInfo.Key == ConsoleKey.Escape) return "";

                if (consoleKeyInfo.Key == ConsoleKey.Backspace)
                {
                    if (enteredCharacters.Count > 0)
                    {
                        var length = mask.Length;

                        Console.CursorLeft -= length;
                        Console.Write(new string(' ', length));
                        Console.CursorLeft -= length;

                        enteredCharacters.Pop();
                    }
                    continue;
                }

                Console.Write(mask);

                enteredCharacters.Push(consoleKeyInfo.KeyChar);
            }

            Console.WriteLine();

            return new string(enteredCharacters.Reverse().ToArray());
        }
    }
}
