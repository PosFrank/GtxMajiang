using System;
using System.Collections.Generic;

namespace Simulator.Models
{
    public class Pai
    {
        public readonly Guid _id;
        private readonly PaiType _type;

        public Pai(PaiType name)
        {
            _type = name;
            _id = Guid.NewGuid();
        }

        public PaiType GetType()
        {
            return _type;
        }

        public int GetTypeId()
        {
            return (int)_type;
        }

        public string GetDisplayName()
        {
            return PaiTypeName[_type];
        }

        private static readonly Dictionary<PaiType, string> PaiTypeName = new Dictionary<PaiType, string>()
        {
            { PaiType.Tong1, "一筒"},
            { PaiType.Tong2, "二筒"},
            { PaiType.Tong3, "三筒"},
            { PaiType.Tong4, "四筒"},
            { PaiType.Tong5, "五筒"},
            { PaiType.Tong6, "六筒"},
            { PaiType.Tong7, "七筒"},
            { PaiType.Tong8, "八筒"},
            { PaiType.Tong9, "九筒"},

            { PaiType.Tiao1, "一條"},
            { PaiType.Tiao2, "二條"},
            { PaiType.Tiao3, "三條"},
            { PaiType.Tiao4, "四條"},
            { PaiType.Tiao5, "五條"},
            { PaiType.Tiao6, "六條"},
            { PaiType.Tiao7, "七條"},
            { PaiType.Tiao8, "八條"},
            { PaiType.Tiao9, "九條"},

            { PaiType.Wan1, "一萬"},
            { PaiType.Wan2, "二萬"},
            { PaiType.Wan3, "三萬"},
            { PaiType.Wan4, "四萬"},
            { PaiType.Wan5, "五萬"},
            { PaiType.Wan6, "六萬"},
            { PaiType.Wan7, "七萬"},
            { PaiType.Wan8, "八萬"},
            { PaiType.Wan9, "九萬"},

            { PaiType.East, "东"},
            { PaiType.South, "南"},
            { PaiType.West, "西"},
            { PaiType.North, "北"},
            { PaiType.Middle, "中"},
            { PaiType.BaiBan, "白"},
            { PaiType.FaCai, "發"},

            { PaiType.Mei, "梅"},
            { PaiType.Lan, "蘭"},
            { PaiType.Zhu, "竹"},
            { PaiType.Ju, "菊"},
            { PaiType.Chun, "春"},
            { PaiType.Xia, "夏"},
            { PaiType.Qiu, "秋"},
            { PaiType.Dong, "冬"},
        };
    }

    public enum PaiType
    {
        Tong1 = 0,      //筒
        Tong2 = 1,
        Tong3 = 2,
        Tong4 = 3,
        Tong5 = 4,
        Tong6 = 5,
        Tong7 = 6,
        Tong8 = 7,
        Tong9 = 8,

        Tiao1 = 10,      //条
        Tiao2 = 21,
        Tiao3 = 22,
        Tiao4 = 23,
        Tiao5 = 24,
        Tiao6 = 25,
        Tiao7 = 26,
        Tiao8 = 27,
        Tiao9 = 28,

        Wan1 = 30,      //万
        Wan2 = 31,
        Wan3 = 32,
        Wan4 = 33,
        Wan5 = 34,
        Wan6 = 35,
        Wan7 = 36,
        Wan8 = 37,
        Wan9 = 38,

        East = 40,      //东
        South = 42,     //南
        West = 44,      //西
        North = 46,     //北
        Middle = 48,    //中
        FaCai = 50,        //发
        BaiBan = 52,       //白

        Mei = 54,       //梅
        Lan = 56,       //兰
        Zhu = 58,       //竹
        Ju = 60,        //菊
        Chun = 62,      //春
        Xia = 64,       //夏
        Qiu = 66,       //秋
        Dong = 68,      //冬
    }
}