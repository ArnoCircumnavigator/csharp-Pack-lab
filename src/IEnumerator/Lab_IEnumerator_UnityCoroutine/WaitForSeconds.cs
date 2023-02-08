using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_IEnumerator_UnityCoroutine
{
    internal class WaitForSeconds : YieldInstruction
    {
        float seconds;
        public WaitForSeconds(float seconds)
        {
            this.seconds = seconds;
        }

        public override bool GetFinishedFlag()
        {
            Console.WriteLine("Wiat");
            seconds -= TimeClock.deltaTime;
            return seconds < 0;
        }
    }
}
