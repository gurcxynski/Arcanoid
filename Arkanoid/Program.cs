using System;

namespace Arkanoid
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            using var game = new Arkanoid();
            game.Run();
        }
    }
}
