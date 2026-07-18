using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    internal class InheritingInterface
    {
        interface IWeapon
        {
            void Fire();
        }

        interface IThrowingWeapon : IWeapon
        {
            void Throw();
        }

        class Gun : IWeapon
        {
            public void Fire()
            {
                Console.WriteLine($"{GetType().Name}: Gun is firing!");
            }
        }

        class LaserGun : IWeapon
        {
            public void Fire()
            {
                Console.WriteLine($"{GetType().Name}: Laser is firing!");
            }
        }

        class Knife : IThrowingWeapon
        {
            public void Fire()
            {
                Console.WriteLine($"{GetType().Name}: Cut!");
            }

            public void Throw()
            {
                Console.WriteLine($"{GetType().Name}: Throw!");
            }
        }
        class Player
        {
            public void Fire(IWeapon weapon)
            {
                weapon.Fire();
            }

            public void Throw(IThrowingWeapon throwingWeapon)
            {
                throwingWeapon.Throw();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Player player = new Player();
                //Gun gun = new Gun();
                IWeapon[] inventory = { new Gun(), new LaserGun(), new Knife() };
                foreach (var item in inventory)
                {
                    player.Fire(item);
                    Console.WriteLine();
                }

                player.Throw(new Knife());
            }

        }
    }

}

