// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var lines = File.ReadAllLines("puzzleinput.txt");

var sum = 0;

foreach (var line in lines)
{
    var digits = line.Where(Char.IsDigit).ToArray();

    var first = digits[0];
    var last = digits[digits.Count() - 1];

    string concat = String.Concat(first, last);

    sum += Int32.Parse(concat);

}

Console.WriteLine("SUM: " + sum);