namespace Belowgrid.UI
{
    public static class Theme
    {
        private static readonly Dictionary<ThemeColor, ConsoleColor> _colorMap = new()
        {
            { ThemeColor.Default, ConsoleColor.White },
            { ThemeColor.Player, ConsoleColor.Cyan },
            { ThemeColor.Enemy, ConsoleColor.Red },
            { ThemeColor.Item, ConsoleColor.Yellow },
            { ThemeColor.SystemMessage, ConsoleColor.Gray },
            { ThemeColor.Warning, ConsoleColor.DarkYellow },
            { ThemeColor.Health, ConsoleColor.Green },
            { ThemeColor.Danger, ConsoleColor.DarkRed },
            { ThemeColor.Success, ConsoleColor.Green },
        };

        public static ConsoleColor GetColor(ThemeColor color)
        {
            return _colorMap.TryGetValue(color, out var consoleColor) ? consoleColor : ConsoleColor.White;
        }

        public static void SetColor(ThemeColor color, ConsoleColor consoleColor)
        {
            _colorMap[color] = consoleColor;
        }
    }
}
