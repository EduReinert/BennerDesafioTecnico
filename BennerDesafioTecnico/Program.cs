// See https://aka.ms/new-console-template for more information

Network n = new Network(6);
n.Connect(1, 2);
n.Connect(2, 3);
n.Connect(3, 4);
foreach (int[] c in n.ConnectionsList)
{
    Console.WriteLine($"Connection: {c[0]} <-> {c[1]}");
}

Console.WriteLine(n.Query(1, 2));
Console.WriteLine(n.Query(2, 3));
Console.WriteLine(n.Query(1, 4));