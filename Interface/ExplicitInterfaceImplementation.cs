//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Interface
//{
//    internal class ExplicitInterfaceImplementation
//    {
//        interface IFirstInterface
//        {
//            void Action();
//        }

//        interface ISecondInterface
//        {
//            void Action();
//        }

//        class MyClass : IFirstInterface, ISecondInterface
//        {
//            public void Action()
//            {
//                Console.WriteLine("My class action...");
//            }
//        }

//        class MyOtherClass : IFirstInterface, ISecondInterface
//        {
//            public void IFirstInterface.Action()
//            {
//                Console.WriteLine("MyOtherClass: Action from IFirstInterface");
//            }
//            public void ISecondInterface.Action()
//            {
//                Console.WriteLine("MyOtherClass: Action from ISecondInterface");
//            }
//        }

//        class Program
//        {
//            static void Main(string[] args)
//            {
//                MyClass myClass = new MyClass();
//                //myClass.             - метод Action() присутній
//                Foo(myClass);
//                Bar(myClass);

//                Console.WriteLine();

//                MyOtherClass myOtherClass = new MyOtherClass();
//                //myOtherClass.        - метод Action() відсутній, оскільки він реалізований явно для інтерфейсів
//                                       //і не має модифікатора доступу public

//                Foo(myOtherClass);
//                Bar(myOtherClass);
                  
//                Console.WriteLine("----------------");

//                /* приклад через посилання*/
//                IFirstInterface firstInterface = myOtherClass;
//                firstInterface.Action();
//                ISecondInterface secondInterface = myOtherClass;
//                secondInterface.Action();

//                /* звертання до об'єкта через посилання на інтерфейс, що реалізує метод Action() (оператори is і as) 
//                 * застосовуємо приведення типів 
//                 */
                
//                Console.WriteLine("----------------");

//                ((IFirstInterface)myOtherClass).Action();
//                ((ISecondInterface)myOtherClass).Action();

//                /* object obj = new object();
//                if (obj is IFirstInterface firstInterface1)
//                {
//                    firstInterface.Action();
//                }
//                */

//                Console.WriteLine("^^^^^^^^^^^^^^");

//                if (myOtherClass is IFirstInterface firstInterface1)
//                {
//                    firstInterface.Action();
//                }

//            }

//            static void Foo(IFirstInterface firstInterface)
//            { 
//                firstInterface.Action();
//            }

//            static void Bar(ISecondInterface secondInterface)
//            {
//                secondInterface.Action();
//            }


//            /*
//            void IFirstInterface.Action()
//            {
//                Console.WriteLine("Action from IFirstInterface");
//            }
//            void ISecondInterface.Action()
//            {
//                Console.WriteLine("Action from ISecondInterface");
//            }
//            */
//        }
//    }
//}
