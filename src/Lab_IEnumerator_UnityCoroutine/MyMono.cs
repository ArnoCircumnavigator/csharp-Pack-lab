using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_IEnumerator_UnityCoroutine
{
    /// <summary>
    /// 用重载的方式模仿Unity的Start和Update
    /// 原版Unity这两个方法的实现是另一个话题
    /// </summary>
    internal class MyMono : Monobehaviour
    {
        static IEnumerator foo()
        {
            Console.WriteLine("等待之前的事情");
            yield return new WaitForSeconds(3f);
            Console.WriteLine("等待之后的事情");
        }
        public override void Start()
        {
            StartCoroutine(foo());
        }

        public override void Update()
        {
            //Console.WriteLine("Update");
        }
    }
}
