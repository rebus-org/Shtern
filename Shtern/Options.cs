using System;
using System.Collections.Generic;
using System.Linq;

namespace Shtern
{
    public static class Options
    {
        public static TOption Prompt<TOption>(string text, IEnumerable<TOption> options)
        {
            var list = options.ToList();

            if (!list.Any())
            {
                throw new ArgumentException("Cannot prompt without any options");
            }

            Console.WriteLine(text);

            var selectedIndex = 0;

            var initialCursorTop = Console.CursorTop;

            Action<int> change = value =>
            {
                var newSelectedIndex = selectedIndex + value;
                if (newSelectedIndex < 0) return;
                if (newSelectedIndex > list.Count - 1) return;

                selectedIndex = newSelectedIndex;

                Paint(list, selectedIndex, initialCursorTop);
            };

            Paint(list, selectedIndex, initialCursorTop);

            while (true)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        change(-1);
                        break;

                    case ConsoleKey.DownArrow:
                        change(1);
                        break;

                    case ConsoleKey.Enter:
                        goto returnCurrent;

                    case ConsoleKey.Escape:
                        goto returnDefault;

                    default: continue;
                }
            }

            returnCurrent:
            return list[selectedIndex];

            returnDefault:
            return default(TOption);
        }

        static void Paint<TOption>(List<TOption> list, int selectedIndex, int initialCursorTop)
        {
            Console.CursorTop = initialCursorTop;

            var lines = list
                .Select((option, index) => selectedIndex == index
                    ? $" --> {option}"
                    : $"     {option}")
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, lines));
        }

        static void MoveUp()
        {
            throw new NotImplementedException();
        }

        static void MoveDown()
        {
            throw new NotImplementedException();
        }
    }
}