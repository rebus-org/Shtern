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
        /// Reads a line from the console, outputting a mask character (default: *) for each character entered.
        /// The mast character can be customized by setting <paramref name="maskCharacter"/> to something else
        /// </summary>
        public static string ReadLine(char maskCharacter = '*')
        {
            var enteredCharacters = new Stack<char>();

            while (true)
            {
                var consoleKeyInfo = Console.ReadKey(true);

                if (consoleKeyInfo.Key == ConsoleKey.Enter) break;

                if (consoleKeyInfo.Key == ConsoleKey.Escape) return "";

                if (consoleKeyInfo.Key == ConsoleKey.Backspace)
                {
                    if (enteredCharacters.Count > 0)
                    {
                        Console.CursorLeft--;
                        Console.Write(" ");
                        Console.CursorLeft--;
                        enteredCharacters.Pop();
                    }
                    continue;
                }

                Console.Write(maskCharacter);

                enteredCharacters.Push(consoleKeyInfo.KeyChar);
            }

            Console.WriteLine();

            return new string(enteredCharacters.Reverse().ToArray());
        }
    }
}
