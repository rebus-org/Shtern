using System;
using System.Collections.Generic;
using System.Linq;

namespace Shtern
{
    /// <summary>
    /// Call <see cref="Select{TOption}"/> to show a list of options with an arrow for selecting one of them
    /// </summary>
    public static class Options
    {
        /// <summary>
        /// Selects one option out of the given list, returning the selected option. <code>default(TOption)</code> is returned if
        /// ESC is pressed. Change the displayed pointer by setting <paramref name="arrow"/>
        /// </summary>
        public static TOption Select<TOption>(IEnumerable<TOption> options, string arrow = " --> ")
        {
            var list = options.ToList();

            if (!list.Any())
            {
                throw new ArgumentException("Cannot prompt without any options");
            }

            var selectedIndex = 0;

            var initialCursorTop = Console.CursorTop;

            Action<int> change = value =>
            {
                var newSelectedIndex = selectedIndex + value;
                if (newSelectedIndex < 0) return;
                if (newSelectedIndex > list.Count - 1) return;

                selectedIndex = newSelectedIndex;

                Paint(list, selectedIndex, initialCursorTop, arrow);
            };

            Paint(list, selectedIndex, initialCursorTop, arrow);

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

        static void Paint<TOption>(IEnumerable<TOption> list, int selectedIndex, int initialCursorTop, string arrow)
        {
            Console.CursorTop = initialCursorTop;

            var lines = list
                .Select((option, index) => selectedIndex == index
                    ? $"{arrow}{option}"
                    : $"{new string(' ', arrow.Length)}{option}")
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