using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    internal class DefaultInterfaceImplementation
    {
        public interface ILogger
        {
            //public ILogger() 
            //{

            //}

            //int a;

            void Log(LogLevel logLevel, string message);

            //void Foo()
            //{
            //    Console.WriteLine("Test");
            //}

            //void Bar()
            //{
            //    Console.WriteLine("Bar");
            //}

            //int Sum(int a, int b)
            //{
            //    return a + b;
            //}
            void LogError(string message)
            {
                Log(LogLevel.Error, message);
            }

        }


        public enum LogLevel
        {
            Debug,
            Info,
            Warning,
            Error,
            Fatal
        }

        public class ConsoleLogger : ILogger
        {
            void ILogger.Log(LogLevel logLevel, string message)
            {
                switch(logLevel)
                {
                    case LogLevel.Debug:
                        Console.ForegroundColor = ConsoleColor.Green;
                    break;
                    case LogLevel.Info:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case LogLevel.Warning:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case LogLevel.Error:
                    case LogLevel.Fatal:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                }
                Console.WriteLine($"{DateTime.Now}: {message}");
                Console.ResetColor();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                ILogger consoleLogger = new ConsoleLogger();
                //consoleLogger.Bar();
                consoleLogger.Foo();
                consoleLogger.Log(LogLevel.Debug, "some event");
                consoleLogger.Log(LogLevel.Warning, "some warning");
                consoleLogger.Log(LogLevel.Fatal, "some fatal error");
                consoleLogger.LogError("some error");
            }
        }
    }
}
