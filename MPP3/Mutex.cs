using System.Threading;
using System;


//Задание 3
/*Реализовать консольную программу на языке C#, которая:
- принимает в параметре командной строки путь к сборке .NET
(EXE- или DLL-файлу);
-загружает указанную сборку в память;
-выводит на экран полные имена всех public -типов данных этой
сборки, упорядоченные по пространству имен (namespace) и по
имени.*/

namespace ThirdTask
{
    class Mutex
    {
        private int  currentValue;

        public void Lock()
        {
            while (Interlocked.CompareExchange(ref currentValue, Thread.CurrentThread.ManagedThreadId, 0) != 0)
            {
                Thread.Sleep(1000);
            }
        }

        public void Unlock()
        {
            Interlocked.CompareExchange(ref currentValue, 0, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
