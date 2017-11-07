using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GtxMajiang.Simulator.Models;

namespace GtxMajiang.Simulator
{
    public class Game
    {
        private bool _isGameStarted;
        private readonly Table _table;
        private readonly Dictionary<string, Player> _players;
        private Pai _common;

        public Game()
        {
            _common = null;
            _isGameStarted = false;
            _table = new Table();
            _players = new Dictionary<string, Player>();
        }

        public bool AddPlayer(string name)
        {
            if(IsRoomFull())
            {
                Console.WriteLine("Game: Sorry, the room is full.");
                return false;
            }

            _players.Add(name, new Player(name));

            return true;
        }

        public bool RemovePlayer(string name)
        {
            if (!_players.ContainsKey(name))
            {
                return false;
            }

            _players.Remove(name);

            return true;
        }

        public void StartGame()
        {
            if(!IsRoomFull())
            {
                Console.WriteLine($"Game: Sorry not enough players, you need {4 - _players.Count} more players.");
            }

            _isGameStarted = true;

            //get players order
            //TODO: customize order
            Player[] players = _players.Values.ToArray();

            //initialize a new squire of pais
            Console.WriteLine("Game: Start！！！");
            _table.Initialize();
            Console.WriteLine("Game: Ma Jiang is Ready!");

            Console.WriteLine("Game: Distribute Pais to Players");
            InitiallyDistributePaisToAllPlayers(players);

            //假设庄家是第一个，此设定可变。
            //TODO: customize zhuangjia player
            int turn = 0;

            //给庄家多发一张牌
            GivePlayerPaiFromTable(players[turn], _table);
            Console.WriteLine("Game: Finished Distribution.");

            //检查花牌并补牌
            ExchangeFlowerPai(players[turn]);

            //检查庄家是不是天胡！
            if (CheckIfCurrentPlayerHasHued(players[turn]))
            {
                StopGame($"Congratulations to {players[turn].GetName()} HUUUUUUUUed！！！");
                return;
            }

            //首先庄家出牌
            LetPlayerMakeTheMove(players[turn]);
            Console.WriteLine("\n=================================================================================================");

            //开始轮流摸牌出牌
            while (true)
            {
                //TODO[tigao]: 检查下家是否可以吃
                //检查其他3个玩家的手牌是否可以碰
                if (CheckEachPlayerToPengAndDetermineNextTurn(players, out turn, turn))
                {

                }
                else
                {
                    if (!_table.HasNext())
                    {
                        break;
                    }
                    //让当前玩家摸牌
                    LetPlayerTakePaiFromTable(players[turn]);
                    ExchangeFlowerPai(players[turn]);
                }

                if (CheckIfCurrentPlayerHasHued(players[turn]))
                {
                    StopGame($"Congratulations to {players[turn].GetName()} HUUUUUUUUed！！！");
                    return;
                }

                //让当前玩家出牌
                LetPlayerMakeTheMove(players[turn]);
                Console.WriteLine("\n=================================================================================================");
            }
            
            StopGame("All the pais are used, Even Game!");
        }


        public void StopGame(string message)
        {
            Console.WriteLine($"Game: {message}");

            foreach (var player in _players.Values)
            {
                Console.WriteLine($"Player {player.GetName()}'s PAIs：");
                player.DisplayOnePlayerPais();
                Console.WriteLine();
            }
            Console.WriteLine($"-----Game Over------");

            _isGameStarted = false;
        }

        #region Helpers

        private void LetPlayerTakePaiFromTable(Player player)
        {
            _table.GetPai(out var pai);
            player.AddPai(pai);
        }

        /// <summary>
        /// 检查玩家是否已经胡牌并且询问玩家是否要胡牌
        /// </summary>
        /// <param name="players"></param>
        /// <param name="turn"></param>
        private bool CheckIfCurrentPlayerHasHued(Player player)
        {
            if (player.IsHu())
            {
                Console.WriteLine($"Game: Player {player.GetName()} can HU PAI，Do you want to HU? please enter: YES/NO");
                var isHu = WaitPlayerInput();
                if (isHu.Equals("YES", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 让玩家出牌并且将牌放入common
        /// </summary>
        /// <param name="players"></param>
        /// <param name="turn"></param>
        private void LetPlayerMakeTheMove(Player player)
        {
            Console.WriteLine($"Game: {player.GetName()} please CHU PAI ");
            var dict = player.DisplayOnePlayerPais();
            Console.WriteLine($"Game: Please type the PAI you want to chu and press ENTER");
            int index = int.Parse(WaitPlayerInput());

            //出牌到展示区
            _common = dict[index];

            //删除玩家的手牌
            player.DeletePai(_common);

            //TODO: 用中文
            Console.WriteLine($"Game: Player {player.GetName()} show PAI: [{_common.GetType()}] !");
        }

        private bool CheckEachPlayerToPengAndDetermineNextTurn(Player[] players, out int turn, int inputTurn)
        {
            for (int i = 1; i <= 3; i++)
            {
                int tempTurn = (inputTurn + 1) % 4;
                var player = players[tempTurn];

                if (player.CanPeng(_common) && AskPlayerPeng(player))
                {
                    player.Peng(_common);
                    turn = tempTurn;
                    return true;
                }
            }

            turn = (inputTurn + 1) % 4;

            return false;
        }

        private bool AskPlayerPeng(Player player)
        {
            Console.WriteLine($"Game: {player.GetName()} can PENG! Do you want to peng? Type: YES/NO");
            var input = WaitPlayerInput();

            return input.Equals("YES", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 等待玩家输入指令
        /// </summary>
        /// <returns></returns>
        private string WaitPlayerInput()
        {
            string input = null;

            while (input == null)
            {
                input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Game: Please type the correct message");
                }
            }

            return input;
        }

        /// <summary>
        /// 游戏刚开始时向每个玩家发13张牌
        /// </summary>
        /// <param name="players"></param>
        private void InitiallyDistributePaisToAllPlayers(Player[] players)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    GivePlayerPaiFromTable(players[i], _table);
                }
                Console.WriteLine($"{players[i].GetName()}'s PAIs are ready!");
            }
        }

        /// <summary>
        /// 检查是否有花牌并且同时进行换牌直到没有花牌为止
        /// </summary>
        /// <param name="players"></param>
        /// <param name="turn"></param>
        private void ExchangeFlowerPai(Player player)
        {
            for (var flowers = player.GetNumberOfFlowers();
                flowers.Count > 0;
                flowers = player.GetNumberOfFlowers())
            {
                Console.WriteLine($"Game: there are {flowers.Count} numbers of flower PAI, need to refill");
                foreach (var pai in flowers)
                {
                    player.DeletePai(pai);
                    _table.DisposePai(pai);
                    GivePlayerPaiFromTable(player, _table);
                }
            }
        }

        /// <summary>
        /// 检查是否房间已经满员
        /// </summary>
        /// <returns></returns>
        private bool IsRoomFull()
        {
            return _players.Count >= 4;
        }

        private bool GivePlayerPaiFromTable(Player player, Table table)
        {
            if (!_table.GetPai(out var pai))
            {
                StopGame("All the PAIs are used, Even Game!");
                return false;
            }

            player.AddPai(pai);

            return true;
        }

        #endregion
    }
}
