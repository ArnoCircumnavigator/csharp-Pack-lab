using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_IEnumerator_UnityCoroutine
{
    internal class TimeClock
    {
        /// <summary>
        /// 增量时间 s
        /// </summary>
        public static float deltaTime = 0.2f;
        /// <summary>
        /// 开始到现在执行的总时间 s
        /// </summary>
        public static float time => _time;
        static float _time;

        public List<Monobehaviour> monobehaviours = new();
        public void StartUpdate()
        {
            lock (monobehaviours)
            {
                foreach (Monobehaviour? item in monobehaviours)
                {
                    item.MonoStart();
                }
            }

            DateTime lastUpdateTime = DateTime.Now;
            var timeString = string.Empty;
            while (true)
            {
                if ((DateTime.Now - lastUpdateTime).TotalSeconds > deltaTime)
                {
                    lock (monobehaviours)
                    {
                        foreach (Monobehaviour? item in monobehaviours)
                        {
                            item.MonoUpdate();
                        }
                        _time += deltaTime;
                        timeString = _time.ToString("N1");
                        _ = float.TryParse(timeString, out _time);//处理精度问题
                    }
                    lastUpdateTime = DateTime.Now;
                    //Console.WriteLine("Update");
                    //Console.WriteLine(time);
                }
            }
        }

    }
}
