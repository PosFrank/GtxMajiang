using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Models
{
    public class Player
    {
        public string _name;
        private List<Pai> _privatePais;
        private List<Pai> _publicPais;

        public Player(string name)
        {
            _name = name;
            _privatePais = new List<Pai>();
            _publicPais = new List<Pai>();
        }

        public string GetName()
        {
            return _name;
        }
        
        public List<Pai> GetPrivatePais()
        {
            return _privatePais;
        }

        public List<Pai> GetPublicPais()
        {
            return _publicPais;
        }

        public List<Pai> GetPrivatePaisCopy()
        {
            return new List<Pai>(_privatePais);
        }

        public List<Pai> GetAllPais()
        {
            var rst = new List<Pai>(_privatePais);
            rst.AddRange(_publicPais);
            return rst;
        }


        /// <summary>
        /// 在屏幕上打印出一个玩家的所有牌
        /// </summary>
        /// <returns></returns>
        public Dictionary<int, Pai> DisplayOnePlayerPais()
        {
            var rst = new Dictionary<int, Pai>();
            int index = 1;
            int counter = 1;

            if (_publicPais.Count > 0)
            {
                Console.WriteLine("-----------------------Public PAIs---------------------------");
                foreach (var pai in _publicPais)
                {
                    Console.Write($"[{pai.GetType()}]\t");
                    rst.Add(index++, pai);
                }

                Console.WriteLine();
                foreach (var pai in _publicPais)
                {
                    Console.Write($"{counter++}\t");
                }

                Console.WriteLine();
            }

            Console.WriteLine("-----------------------Hidden PAIs--------------------------");
            foreach (Pai pai in _privatePais)
            {
                //TODO: 用中文!
                Console.Write($"[{pai.GetType()}] ");
                rst.Add(index++, pai);
            }

            Console.WriteLine();
            foreach (Pai pai in _privatePais)
            {
                Console.Write($"{counter++}\t");
            }

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");

            return rst;
        }

        /// <summary>
        /// add a pai to this player
        /// </summary>
        /// <param name="pai"></param>
        public void AddPai(Pai pai)
        {
            if(_privatePais.Count + _publicPais.Count >= 14)
            {
                throw new InvalidOperationException($"Sorry, this play already has {_privatePais.Count + _publicPais.Count} number of PAIs");
            }

            _privatePais.Add(pai);

            _privatePais.Sort(ComparePai);
        }
        static int ComparePai(Pai a, Pai b)
        {
            // Return result of CompareTo with lengths of both strings.
            return a.GetTypeId().CompareTo(b.GetTypeId());
        }

        /// <summary>
        /// delete the input pai
        /// </summary>
        /// <param name="pai"></param>
        /// <returns></returns>
        public void DeletePai(Pai pai)
        {
            _privatePais.Remove(pai);
        }
        
        public List<Pai> GetNumberOfFlowers()
        {
            return _privatePais.Where(x => x.GetTypeId() >= 54).ToList<Pai>();

        }

        public bool CanChi(Pai pai)
        {
            var list = new List<int>(_privatePais.ConvertAll(x => x.GetTypeId()));
            list.Add(pai.GetTypeId());
            list.Sort();

            for(int i = 0; i < 11; i++)
            {
                if (list[i] + 1 == list[i + 1] && list[i + 1] + 1 == list[i + 2])
                {
                    return true;
                }
            }

            return false;
        }

        public bool CanPeng(Pai pai)
        {
            var list = new List<int>(_privatePais.ConvertAll(x => x.GetTypeId()));
            list.Add(pai.GetTypeId());
            list.Sort();

            for (int i = 0; i < 11; i++)
            {
                if (list[i] == list[i + 1] && list[i + 1] == list[i + 2])
                {
                    return true;
                }
            }

            return false;
        }

        public void Chi(Pai pai)
        {
            
        }

        public void Peng(Pai pai)
        {
            var same = _privatePais.Where(x => x.GetType() == pai.GetType());
            _publicPais.AddRange(same);
            _publicPais.Add(pai);
            _privatePais.RemoveAll(x => x.GetType() == pai.GetType());
        }

        public bool IsHu(Pai pai = null)
        {
            var list = new List<int>();
            list.AddRange(_privatePais.ConvertAll(x => x.GetTypeId()));
            list.AddRange(_publicPais.ConvertAll(x => x.GetTypeId()));

            if (pai != null)
            {
                list.Add(pai.GetTypeId());
            }

            list.Sort();
            var paiArray = list.ToArray();

            //check 十三幺 和 7对
            if(Is13Yao(paiArray) || Is7Dui(paiArray))
            {
                return true;
            }

            //check 普通胡法 (aaa)*(bcd)*ee
            return IsHuHelper(0, paiArray, false);
        }

        private bool IsHuHelper(int i, int[] array, bool seenDui)
        {
            if (i == array.Length)
            {
                return true;
            }
            
            if(!seenDui && IsDui(i, array))
            {
                return IsHuHelper(i + 2, array, true);
            }

            if(IsKeOrShun(i, array))
            {
                return IsHuHelper(i + 3, array, seenDui);
            }

            return false;
        }

        /// <summary>
        /// 是不是 刻子 或者 顺子
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        private bool IsKeOrShun(int i, int[] paiArray)
        {
            if(paiArray.Length - i < 3)
            {
                return false;
            }

            int a = paiArray[i];
            int b = paiArray[i + 1];
            int c = paiArray[i + 2];

            return (a == b && b == c) || (a + 1 == b && b + 1 == c);
        }

        /// <summary>
        /// 是不是对子
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private bool IsDui(int i, int[] paiArray)
        {
            if(paiArray.Length - i < 2)
            {
                return false;
            }

            int a = paiArray[i];
            int b = paiArray[i + 1];

            return a == b;
        }

        /// <summary>
        /// 11 22 33 44 55 66 77
        /// </summary>
        /// <returns></returns>
        private bool Is7Dui(int[] array)
        {
            for(int i = 0; i < array.Length; i +=2)
            {
                if(array[i] != array[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 19 19 19 东南西北中发白
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private bool Is13Yao(int[] array)
        {
            return Enumerable.SequenceEqual(array, new int[] { 0, 8, 10, 28, 30, 38, 40, 42, 44, 46, 48, 50, 52 });
        }
    }
}