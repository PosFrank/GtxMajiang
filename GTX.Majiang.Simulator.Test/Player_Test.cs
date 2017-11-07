using System;
using GtxMajiang.Simulator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GtxMajiang.Simulator.Test
{
    [TestClass]
    public class Player_Test
    {
        [TestMethod]
        public void Player_GetAllPais()
        {
            var p = new Player("Test");
            p.AddPai(new Pai(PaiType.Tiao1));
            p.AddPai(new Pai(PaiType.Tiao2));
            p.AddPai(new Pai(PaiType.Tiao3));
            p.AddPai(new Pai(PaiType.Tiao4));
            p.AddPai(new Pai(PaiType.Tiao5));
            p.AddPai(new Pai(PaiType.Tiao6));
            p.AddPai(new Pai(PaiType.Tiao7));
            p.AddPai(new Pai(PaiType.Tiao8));
            p.AddPai(new Pai(PaiType.Tiao9));
            p.AddPai(new Pai(PaiType.Tong1));
            p.AddPai(new Pai(PaiType.Tong2));
            p.AddPai(new Pai(PaiType.Tong2));
            p.AddPai(new Pai(PaiType.Tong3));
        }
    }
}
