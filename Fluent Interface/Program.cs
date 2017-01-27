using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fluent_Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero kaleTron = FluentHeroFactory
                .Init()
                .GiveAGravatar("C:\\kaleTron.jpg")
                .GiveAColar("Gold")
                .GiveANickName("KaleTron")
                .SetForceTo(60)
                .TakeAHero();

        }
    }

    class Hero
    {
        public string NickName { get; set; }
        public string Color { get; set; }
        public byte[] Gravatar { get; set; }
        public int InitialForce { get; set; }
    }

    interface IHeroFactory
    {
        Hero TakeAHero();
        IHeroFactory SetForceTo(int ForceValue);
        IHeroFactory GiveANickName(string NickName);
        IHeroFactory GiveAGravatar(string GravatarPath);
        IHeroFactory GiveAColar(string Color);
    }

    class HeroFactory
        : IHeroFactory
    {

        private Hero _hero = null;

        public HeroFactory(Hero hero)
        {
            _hero=hero;
        }

        public Hero TakeAHero()
        {
            return this._hero;
        }

        public IHeroFactory SetForceTo(int ForceValue)
        {
            this._hero.InitialForce = ForceValue;
            return this;
        }

        public IHeroFactory GiveANickName(string NickName)
        {
            this._hero.NickName = NickName;
            return this;
        }

        public IHeroFactory GiveAGravatar(string GravatarPath)
        {
            this._hero.Gravatar = GetGravatar(PicPath:GravatarPath);
            return this;
        }

        private byte[] GetGravatar(string PicPath)
        {
            return null;
        }

        public IHeroFactory GiveAColar(string Color)
        {
            this._hero.Color = Color;
            return this;
        }
    }

    static class FluentHeroFactory
    {
        public static IHeroFactory Init()
        {
            return new HeroFactory(new Hero());
        }
    }

}
