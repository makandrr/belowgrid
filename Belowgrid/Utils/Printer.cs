using Belowgrid.UI;

namespace Belowgrid.Utils
{
    static class Printer
    {
        public static void Print(string text, ThemeColor color = ThemeColor.Default)
        {
            Console.ForegroundColor = Theme.GetColor(color);
            Console.Write(text);
            Console.ResetColor();
        }

        public static void PrintLine(string text, ThemeColor color = ThemeColor.Default)
        {
            Console.ForegroundColor = Theme.GetColor(color);
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }
}
