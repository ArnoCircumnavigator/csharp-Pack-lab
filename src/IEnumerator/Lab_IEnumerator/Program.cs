// See https://aka.ms/new-console-template for more information
using Lab_IEnumerator;

Console.WriteLine("Hello, World!");

MyCollection road = new();
road.AddData(new(1));
road.AddData(new(2));
road.AddData(new(3));
road.AddData(new(4));

//method 1
Console.WriteLine("method 1");
foreach (var data in road)
{
    Console.WriteLine(data.value);
}

Console.WriteLine("method 2");

//method 2   两个迭代器一起的情况
IEnumerator<Data>? ienumerator = road.GetEnumerator();
while (ienumerator.MoveNext())
{
    Console.WriteLine(ienumerator.Current.value);

    IEnumerator<Data> temp = road.GetEnumerator();//再搞一个迭代器并行
    while (temp.MoveNext())
    {
        Console.WriteLine("另一个并行的迭代器" + temp.Current.value);
    }
}

Console.ReadLine();
