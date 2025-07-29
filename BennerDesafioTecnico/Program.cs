// See https://aka.ms/new-console-template for more information


//TESTES
Network n = new Network(20);
n.Connect(1, 2);
n.Connect(2, 3);
n.Connect(3, 4);
n.Connect(4, 5);
n.Connect(5, 6);
n.Connect(6, 7);
n.Connect(7, 8);
n.Connect(8, 9);
n.Connect(9, 10);
n.Connect(10, 11);
n.Connect(14, 15);

//ESPERADO : true 
Console.WriteLine(n.Query(1, 2));
Console.WriteLine(n.Query(2, 3));
Console.WriteLine(n.Query(1, 4));
Console.WriteLine(n.Query(4, 10));
Console.WriteLine(n.Query(10, 2));

//ESPERADO : false
Console.WriteLine(n.Query(12, 1));
Console.WriteLine(n.Query(14, 1));
Console.WriteLine(n.Query(19, 20));
