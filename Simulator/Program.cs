using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    class Program
    {
        public static void Main()
        {
            var game = new Game();
            game.AddPlayer("GTX");
            game.AddPlayer("Zhou Jie Lun");
            game.AddPlayer("Chen Yi Xun");
            game.AddPlayer("Bill Gates");
            game.StartGame();
        }
    }
}
