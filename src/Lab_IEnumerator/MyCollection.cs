using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_IEnumerator
{
    internal class MyCollection : IEnumerable<Data>
    {
        readonly List<Data> datas = new();
        public Data this[int index]
        {
            get
            {
                return datas[index];
            }
        }

        public bool AddData(Data data)
        {
            this.datas.Add(data);
            return true;
        }

        public IEnumerator<Data> GetEnumerator()
        {
            return new MyCollectionDataEnumerator(this, this.datas.Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class MyCollectionDataEnumerator : IEnumerator<Data>
    {
        private readonly MyCollection collection;
        private readonly int count;
        private int index;
        public MyCollectionDataEnumerator(MyCollection road, int count)
        {
            this.collection = road;
            this.index = -1;
            this.count = count;
        }

        public Data Current => collection[index];

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            ++index;
            //只有这个为正的时候，才能够往后
            return index < count;
        }

        public void Reset()
        {
            index = -1;
        }
    }

    internal class Data
    {
        public int value;

        public Data(int value)
        {
            this.value = value;
        }
    }
}
