namespace Belowgrid.Input
{
    public class InputManager
    {
        private ConsoleKey? _currentKey;

        public void PollInput()
        {

            _currentKey = null;

            if (Console.KeyAvailable)
            {
                _currentKey = Console.ReadKey(true).Key;
            }
        }

        public ConsoleKey? GetKey()
        {
            return _currentKey;
        }
    }
}
