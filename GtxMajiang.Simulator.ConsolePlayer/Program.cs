using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GtxMajiang.Simulator.ConsolePlayer
{
    class Program
    {
        static void Main(string[] args)
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
