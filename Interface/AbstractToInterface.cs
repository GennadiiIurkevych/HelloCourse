//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Interface
//{
//    class AbstractToInterface
//    {
//        interface IHasInfo
//        {
//            void ShowInfo();
//        }

//        interface IWeapon
//        {
//            int Damage { get; }
//            void Fire();
//        }

//        abstract class Weapon : IHasInfo, IWeapon 
//        {
//            public abstract int Damage { get; }
//            public abstract void Fire();
//            public void ShowInfo()
//            {
//                Console.WriteLine($"{GetType().Name} Damage: {Damage}");
//            }
//        }

//        class Gun : Weapon
//        {
//            public override int Damage { get { return 5; } }

//            public override void Fire()
//            {
//                Console.WriteLine("Gun is firing!");
//            }
//        }

//        class LaserGun : Weapon
//        {
//            public override int Damage => 10;

//            public override void Fire()
//            {
//                Console.WriteLine("Laser is firing!");
//            }
//        }

//        class Bow : Weapon
//        {
//            public override int Damage => 3;

//            public override void Fire()
//            {
//                Console.WriteLine("The arrow flew to the target!");
//            }
//        }

//        class Player
//        {
//            public void Fire(IWeapon weapon)
//            {
//                weapon.Fire();
//            }
//            public void CheckInfo(IHasInfo hasInfo)
//            {
//                hasInfo.ShowInfo();
//            }
//        }

//        class Box : IHasInfo
//        {
//            public void ShowInfo()
//            {
//                Console.WriteLine("This is a box.");
//            }
//        }
                
//        static void Main(string[] args)
//        {
//            Player player = new Player();
//            //Gun gun = new Gun();
//            Weapon[] inventory = { new Gun(), new LaserGun(), new Bow() };
//            foreach (var item in inventory)
//            {
//                player.CheckInfo(item);
//                player.Fire(item);
//                Console.WriteLine();
//            }
//                player.CheckInfo(new Box());
//        }
        
//    }
//}
