using System;
using GtxMajiang.Simulator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GtxMajiang.Simulator.Test
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void Game_PlayTest()
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
