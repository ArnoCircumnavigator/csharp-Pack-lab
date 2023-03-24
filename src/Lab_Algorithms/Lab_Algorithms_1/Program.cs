using System.Text;

namespace Lab_Algorithms_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //计划量
            Dictionary<char, int> plan = new()
            {
                { 'a',100},
                { 'b',200},
                { 'c',300},
                { 'd',45},
                { 'e',6},
                { 'f',6},
            };
            //b,b,b,a,c,b,b,b,a,b,b,b,a,c,

            //总计划量
            int total = plan.Values.Sum();
            Console.WriteLine($"总计划量{total}");
            //单元增量
            float detal = 0;
            List<int> sortValues = plan.Values.ToList();
            sortValues.Sort(delegate (int x, int y) { return y.CompareTo(x); });
            detal = sortValues[0];
            for (int i = 0; i < sortValues.Count - 1; i++)
            {
                var next = sortValues[i + 1];
                detal /= next;
            }
            Console.WriteLine($"单元增量{detal}");

            //当前量
            Dictionary<char, int> current = new();
            //最大趋势量
            Dictionary<char, int> maxtendency = new();
            //当前趋势量
            Dictionary<char, float> tendency = new();
            foreach (var item in plan)
            {
                maxtendency.Add(item.Key, (int)(item.Value / detal));
                current.Add(item.Key, 0);
                tendency.Add(item.Key, 0F);
            }

            List<char> result = new List<char>();

            static int GetNextIndex(int index, int count)
            {
                return (index + 1) % count;
            }

            for (int i = 0, j = 0; i < total; i++)
            {
                //找出能分配的key集合
                var enableAllotKeys = plan.Keys.Where(c => plan[c] > current[c]);
                //找出能分配的这些key中，增量在合理范围的
                enableAllotKeys = Selector(enableAllotKeys.ToList());
                //无法匹配，则认为一个增量周期结束
                if (!enableAllotKeys.Any())
                {
                    foreach (var key in tendency.Keys)
                        tendency[key] = 0;
                    //重新Selector
                    enableAllotKeys = Selector(plan.Keys.Where(c => plan[c] > current[c]).ToList());
                }

                //找出能分配的这些key中，增量最小的那个
                char c = default;//目标key
                float t = float.MinValue;
                foreach (char key in enableAllotKeys)
                {
                    if (plan[key] > t)
                    {
                        t = plan[key];
                        c = key;
                    }
                }
                //当前量
                current[c]++;
                //趋势增量
                tendency[c] += detal;

                Console.WriteLine($"{c}:当前{current[c]}，增量{tendency[c]}");
                //命中了，也要往后移
                j = GetNextIndex(j, plan.Count);
                //结果
                result.Add(c);
            }
            // (a,b,b,b,c,a,b,b,b,a,c)
            // weight//当前周期的权重

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("结果量：" + result.Count.ToString());
            foreach (var r in result)
            {
                sb.Append(r + ",");
            }
            Console.WriteLine(sb.ToString());



            IEnumerable<char> Selector(List<char> enumerator)
            {
                List<char> result = new List<char>();
                //计算enumerator中，增量在合理范围中的
                foreach (var n in enumerator)
                {
                    var tn = tendency[n];
                    var pn = plan[n];
                    bool enable = true;
                    foreach (var m in enumerator)
                    {
                        if (n == m)
                            continue;

                        var tm = tendency[m];
                        var pm = plan[m];

                        if (tendency[m] == 0)
                        {
                            if ((float)tn / detal >= (float)pn / pm)
                            {
                                enable = false;
                            }
                        }
                        else
                        {
                            if ((float)tn / tm >= (float)pn / pm)
                            {
                                enable = false;
                            }
                        }

                    }
                    if (enable)
                        result.Add(n);
                }
                return result;
            }
        }
    }
}