using System.Diagnostics;
using Task_6;
Console.OutputEncoding = System.Text.Encoding.UTF8;

var sw = new Stopwatch();
sw.Start();

var fileReader = new FileReader(@"D:\C#\Task_6\ukraine_poi.csv", new Dictionary<Point, string>());
fileReader.ReadFile();
fileReader.SearchForPlaces(new Point(48.46079, 38.82552),5);
sw.Stop();
Console.WriteLine($"Elapsed time: {sw.Elapsed}");

var pointMin = fileReader.FindMinCoords();
var pointMax = fileReader.FindMaxCoords();

Console.WriteLine();

Node BuildKd()
{
    var pointMin = fileReader.FindMinCoords();
    var pointMax = fileReader.FindMaxCoords();
    var root = new Node(new Rectangle(pointMin, pointMax, fileReader.GetData()), null, null);
    return null;
}






























// while (true)
// {
//     Console.WriteLine("Enter longitude:");
//     var longitude = Console.ReadLine();
//     Console.WriteLine("Enter latitude:");
//     var latitude = Console.ReadLine();
//     Console.WriteLine("Enter radius");
//     var r = Console.ReadLine();
//     fileReader.SearchForPlaces(new Point(double.Parse(longitude), double.Parse(latitude)), int.Parse(r));
//     Console.WriteLine("One more locations[Yes/No]");
//     var end = Console.ReadLine(); 
//     
//     {
//         if(end.ToUpper() == "NO") { break; }
//     }
// }



