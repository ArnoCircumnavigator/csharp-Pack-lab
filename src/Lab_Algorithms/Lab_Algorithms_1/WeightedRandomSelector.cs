namespace Lab_Algorithms_1
{
    // 定义一个泛型类WeightedRandomSelector，它接受一个元素列表，每个元素都是一个Tuple，第一个元素是元素本身，第二个元素是权重值。
    class WeightedRandomSelector<T>
    {
        private List<Tuple<T, int>> elements; // 元素列表
        private Random rand; // 随机数生成器

        public WeightedRandomSelector(List<Tuple<T, int>> elements)
        {
            this.elements = elements;
            this.rand = new Random();
        }

        // GetRandomElement方法使用上述算法从元素列表中随机选择一个元素
        public T GetRandomElement()
        {
            int total_weight = 0;
            foreach (var element in elements)
            {
                total_weight += element.Item2;
            }

            int random_num = rand.Next(total_weight);

            int weight_sum = 0;
            foreach (var element in elements)
            {
                weight_sum += element.Item2;
                if (random_num < weight_sum)
                {
                    return element.Item1;
                }
            }

            // Should never get here
            throw new Exception("Error: WeightedRandomSelector failed to select an element");
        }
    }

}
