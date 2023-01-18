using System;
using System.Collections;

namespace Lab_IEnumerator_UnityCoroutine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 起一个定时器，模仿Unity的刷新机制
             */
            TimeClock timeClock = new();
            Thread unityMainThread = new(new ParameterizedThreadStart(
                (_) => timeClock.StartUpdate()))
            {
                IsBackground = true
            };
            unityMainThread.Start();
            
            /*
             * 收集Mono对象，模仿Untiy场景文件里那些Monobehaviour脚本
             */
            lock (timeClock)
            {
                MyMono mono = new();
                timeClock.monobehaviours.Add(mono);
            }
            
            Console.ReadLine();
        }
    }
}

