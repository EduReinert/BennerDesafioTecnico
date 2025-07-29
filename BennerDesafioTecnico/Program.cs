// See https://aka.ms/new-console-template for more information


//TESTES
Network n = new Network(8);
n.Connect(1, 6);
n.Connect(1, 2);
n.Connect(6, 2);
n.Connect(2, 4);
n.Connect(5, 8);

// erro: conexão já existente
n.Connect(8, 5);
// erro: conexão com mesmos parâmetros
n.Connect(1, 1);

//ESPERADO : true 
// conexões diretas
Console.WriteLine(n.Query(1, 2));
Console.WriteLine(n.Query(8, 5));
Console.WriteLine(n.Query(1, 6));
// conexões indiretas
Console.WriteLine(n.Query(6, 4));
Console.WriteLine(n.Query(4, 1));

//ESPERADO : false
Console.WriteLine(n.Query(5, 1));
Console.WriteLine(n.Query(3, 7));
// mesmo número, esperado: false
Console.WriteLine(n.Query(1, 1));
