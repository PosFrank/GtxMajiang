using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Models
{
    public class Table
    {
        private static readonly Random random = new Random();
        private List<Pai> _newPai;
        private List<Pai> _usedPai;
        
        public Table()
        {
            _newPai = new List<Pai>();
            _usedPai = new List<Pai>();
        }
        
        public bool GetPai(out Pai pai)
        {
            pai = _newPai[0];
            _newPai.RemoveAt(0);
            return true;
        }

        public bool DisposePai(Pai pai)
        {
            if(pai == null)
            {
                return false;
            }

            _usedPai.Add(pai);
            return true;
        }

        public bool HasNext()
        {
            return _newPai.Count > 0;
        }

        /// <summary>
        /// Initialize a new pai array
        /// </summary>
        /// <returns>
        /// an ordered list of pai
        /// </returns>
        public void Initialize()
        {
            _newPai.Clear();
            _usedPai.Clear();

            ConstructPaiSquire(_newPai);

            if (_newPai.Count != 144)
            {
                throw new FormatException($"Sorry, the initialize failed, current length is {_newPai.Count}.");
            }
        }


        private static void ConstructPaiSquire(List<Pai> paiDui)
        {
            if(paiDui.Count > 0)
            {
                throw new InvalidOperationException("Please clean up the list first");
            }

            paiDui.Add(new Pai(PaiType.Tong1));
            paiDui.Add(new Pai(PaiType.Tong2));
            paiDui.Add(new Pai(PaiType.Tong3));
            paiDui.Add(new Pai(PaiType.Tong4));
            paiDui.Add(new Pai(PaiType.Tong5));
            paiDui.Add(new Pai(PaiType.Tong6));
            paiDui.Add(new Pai(PaiType.Tong7));
            paiDui.Add(new Pai(PaiType.Tong8));
            paiDui.Add(new Pai(PaiType.Tong9));
            paiDui.Add(new Pai(PaiType.Tiao1));
            paiDui.Add(new Pai(PaiType.Tiao2));
            paiDui.Add(new Pai(PaiType.Tiao3));
            paiDui.Add(new Pai(PaiType.Tiao4));
            paiDui.Add(new Pai(PaiType.Tiao5));
            paiDui.Add(new Pai(PaiType.Tiao6));
            paiDui.Add(new Pai(PaiType.Tiao7));
            paiDui.Add(new Pai(PaiType.Tiao8));
            paiDui.Add(new Pai(PaiType.Tiao9));
            paiDui.Add(new Pai(PaiType.Wan1));
            paiDui.Add(new Pai(PaiType.Wan2));
            paiDui.Add(new Pai(PaiType.Wan3));
            paiDui.Add(new Pai(PaiType.Wan4));
            paiDui.Add(new Pai(PaiType.Wan5));
            paiDui.Add(new Pai(PaiType.Wan6));
            paiDui.Add(new Pai(PaiType.Wan7));
            paiDui.Add(new Pai(PaiType.Wan8));
            paiDui.Add(new Pai(PaiType.Wan9));
            paiDui.Add(new Pai(PaiType.East));
            paiDui.Add(new Pai(PaiType.South));
            paiDui.Add(new Pai(PaiType.West));
            paiDui.Add(new Pai(PaiType.North));
            paiDui.Add(new Pai(PaiType.Middle));
            paiDui.Add(new Pai(PaiType.FaCai));
            paiDui.Add(new Pai(PaiType.BaiBan));

            paiDui.Add(new Pai(PaiType.Tong1));
            paiDui.Add(new Pai(PaiType.Tong2));
            paiDui.Add(new Pai(PaiType.Tong3));
            paiDui.Add(new Pai(PaiType.Tong4));
            paiDui.Add(new Pai(PaiType.Tong5));
            paiDui.Add(new Pai(PaiType.Tong6));
            paiDui.Add(new Pai(PaiType.Tong7));
            paiDui.Add(new Pai(PaiType.Tong8));
            paiDui.Add(new Pai(PaiType.Tong9));
            paiDui.Add(new Pai(PaiType.Tiao1));
            paiDui.Add(new Pai(PaiType.Tiao2));
            paiDui.Add(new Pai(PaiType.Tiao3));
            paiDui.Add(new Pai(PaiType.Tiao4));
            paiDui.Add(new Pai(PaiType.Tiao5));
            paiDui.Add(new Pai(PaiType.Tiao6));
            paiDui.Add(new Pai(PaiType.Tiao7));
            paiDui.Add(new Pai(PaiType.Tiao8));
            paiDui.Add(new Pai(PaiType.Tiao9));
            paiDui.Add(new Pai(PaiType.Wan1));
            paiDui.Add(new Pai(PaiType.Wan2));
            paiDui.Add(new Pai(PaiType.Wan3));
            paiDui.Add(new Pai(PaiType.Wan4));
            paiDui.Add(new Pai(PaiType.Wan5));
            paiDui.Add(new Pai(PaiType.Wan6));
            paiDui.Add(new Pai(PaiType.Wan7));
            paiDui.Add(new Pai(PaiType.Wan8));
            paiDui.Add(new Pai(PaiType.Wan9));
            paiDui.Add(new Pai(PaiType.East));
            paiDui.Add(new Pai(PaiType.South));
            paiDui.Add(new Pai(PaiType.West));
            paiDui.Add(new Pai(PaiType.North));
            paiDui.Add(new Pai(PaiType.Middle));
            paiDui.Add(new Pai(PaiType.FaCai));
            paiDui.Add(new Pai(PaiType.BaiBan));

            paiDui.Add(new Pai(PaiType.Tong1));
            paiDui.Add(new Pai(PaiType.Tong2));
            paiDui.Add(new Pai(PaiType.Tong3));
            paiDui.Add(new Pai(PaiType.Tong4));
            paiDui.Add(new Pai(PaiType.Tong5));
            paiDui.Add(new Pai(PaiType.Tong6));
            paiDui.Add(new Pai(PaiType.Tong7));
            paiDui.Add(new Pai(PaiType.Tong8));
            paiDui.Add(new Pai(PaiType.Tong9));
            paiDui.Add(new Pai(PaiType.Tiao1));
            paiDui.Add(new Pai(PaiType.Tiao2));
            paiDui.Add(new Pai(PaiType.Tiao3));
            paiDui.Add(new Pai(PaiType.Tiao4));
            paiDui.Add(new Pai(PaiType.Tiao5));
            paiDui.Add(new Pai(PaiType.Tiao6));
            paiDui.Add(new Pai(PaiType.Tiao7));
            paiDui.Add(new Pai(PaiType.Tiao8));
            paiDui.Add(new Pai(PaiType.Tiao9));
            paiDui.Add(new Pai(PaiType.Wan1));
            paiDui.Add(new Pai(PaiType.Wan2));
            paiDui.Add(new Pai(PaiType.Wan3));
            paiDui.Add(new Pai(PaiType.Wan4));
            paiDui.Add(new Pai(PaiType.Wan5));
            paiDui.Add(new Pai(PaiType.Wan6));
            paiDui.Add(new Pai(PaiType.Wan7));
            paiDui.Add(new Pai(PaiType.Wan8));
            paiDui.Add(new Pai(PaiType.Wan9));
            paiDui.Add(new Pai(PaiType.East));
            paiDui.Add(new Pai(PaiType.South));
            paiDui.Add(new Pai(PaiType.West));
            paiDui.Add(new Pai(PaiType.North));
            paiDui.Add(new Pai(PaiType.Middle));
            paiDui.Add(new Pai(PaiType.FaCai));
            paiDui.Add(new Pai(PaiType.BaiBan));

            paiDui.Add(new Pai(PaiType.Tong1));
            paiDui.Add(new Pai(PaiType.Tong2));
            paiDui.Add(new Pai(PaiType.Tong3));
            paiDui.Add(new Pai(PaiType.Tong4));
            paiDui.Add(new Pai(PaiType.Tong5));
            paiDui.Add(new Pai(PaiType.Tong6));
            paiDui.Add(new Pai(PaiType.Tong7));
            paiDui.Add(new Pai(PaiType.Tong8));
            paiDui.Add(new Pai(PaiType.Tong9));
            paiDui.Add(new Pai(PaiType.Tiao1));
            paiDui.Add(new Pai(PaiType.Tiao2));
            paiDui.Add(new Pai(PaiType.Tiao3));
            paiDui.Add(new Pai(PaiType.Tiao4));
            paiDui.Add(new Pai(PaiType.Tiao5));
            paiDui.Add(new Pai(PaiType.Tiao6));
            paiDui.Add(new Pai(PaiType.Tiao7));
            paiDui.Add(new Pai(PaiType.Tiao8));
            paiDui.Add(new Pai(PaiType.Tiao9));
            paiDui.Add(new Pai(PaiType.Wan1));
            paiDui.Add(new Pai(PaiType.Wan2));
            paiDui.Add(new Pai(PaiType.Wan3));
            paiDui.Add(new Pai(PaiType.Wan4));
            paiDui.Add(new Pai(PaiType.Wan5));
            paiDui.Add(new Pai(PaiType.Wan6));
            paiDui.Add(new Pai(PaiType.Wan7));
            paiDui.Add(new Pai(PaiType.Wan8));
            paiDui.Add(new Pai(PaiType.Wan9));
            paiDui.Add(new Pai(PaiType.East));
            paiDui.Add(new Pai(PaiType.South));
            paiDui.Add(new Pai(PaiType.West));
            paiDui.Add(new Pai(PaiType.North));
            paiDui.Add(new Pai(PaiType.Middle));
            paiDui.Add(new Pai(PaiType.FaCai));
            paiDui.Add(new Pai(PaiType.BaiBan));

            paiDui.Add(new Pai(PaiType.Mei));
            paiDui.Add(new Pai(PaiType.Lan));
            paiDui.Add(new Pai(PaiType.Zhu));
            paiDui.Add(new Pai(PaiType.Ju));

            paiDui.Add(new Pai(PaiType.Chun));
            paiDui.Add(new Pai(PaiType.Xia));
            paiDui.Add(new Pai(PaiType.Qiu));
            paiDui.Add(new Pai(PaiType.Dong));

            Randomize(paiDui);
        }

        /// <summary>
        /// randomize the ordered pai array
        /// </summary>
        private static void Randomize(List<Pai> paiDui)
        {
            for (int currentIndex = paiDui.Count - 1; currentIndex > 0; currentIndex--)
            {
                int preIndex = random.Next(currentIndex);
                Pai temp = paiDui[currentIndex];
                paiDui[currentIndex] = paiDui[preIndex];
                paiDui[preIndex] = temp;
            }
        }
    }
}