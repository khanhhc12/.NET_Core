﻿using HelloWorld;

// Task timeout
//SimpleTask.Test();
//var i = SimpleConvert.To<int>("123");
List<string> words = new List<string> { "A", "B", "C" };
var list = SimpleConvert.SplitList<string>(words, 2);
foreach (var item in list)
{
    Console.WriteLine(string.Join(" ", item));
}
list = SimpleConvert.SplitList<string>(words, 4);
foreach (var item in list)
{
    Console.WriteLine(string.Join(" ", item));
}
list = SimpleConvert.SplitList<string>(words, 0);
foreach (var item in list)
{
    Console.WriteLine(string.Join(" ", item));
}
Console.WriteLine("Hello World!");
Console.Read();
