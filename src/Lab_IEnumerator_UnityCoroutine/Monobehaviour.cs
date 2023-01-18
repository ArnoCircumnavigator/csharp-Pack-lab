using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_IEnumerator_UnityCoroutine
{
    internal class Monobehaviour
    {
        private readonly LinkedList<IEnumerator> iEnumerators = new();
        internal void MonoStart()
        {
            Start();
        }
        internal void MonoUpdate()
        {
            Update();

            var node = iEnumerators.First;
            while (node != null)
            {
                var ie = node.Value;
                var result = true;
                if (ie.Current is YieldInstruction yield)
                {
                    if (yield.GetFinishedFlag())//做完了
                    {
                        result = ie.MoveNext();//往后移
                    }
                }
                else
                    result = ie.MoveNext();

                if (!result)//迭代器到头了，
                    iEnumerators.Remove(node);

                node = node.Next;
            }
        }
        public virtual void Start() { }
        public virtual void Update() { }

        protected void StartCoroutine(IEnumerator enumerator)
        {
            iEnumerators.AddLast(enumerator);
        }

        protected void StopCoroutine(IEnumerator enumerator)
        {
            //如果集合中有两个一样的，移除先加进来的
            iEnumerators.Remove(enumerator);
        }
    }
}
