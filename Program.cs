using Task_6;

Console.WriteLine("Hello, World!");
// var point = new Point(50.60659, 30.45436);
// point.Print();
// point.Print();
var fileReader = new FileReader(@"D:\C#\Task_6\map.txt", new Dictionary<Point, string>());
fileReader.ReadFile();
Console.WriteLine();
