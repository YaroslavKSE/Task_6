using System.Diagnostics;
using Task_6;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var sw = new Stopwatch();
sw.Start();

var fileReader = new FileReader(@"D:\C#\Task_6\ukraine_poi.csv", new Dictionary<Point, string>());
fileReader.ReadFile();
// fileReader.SearchForPlaces(new Point(48.46079, 38.82552), 5);
var pointMin = fileReader.FindMinCoords();
var pointMax = fileReader.FindMaxCoords();
var pointsQuantity = fileReader.GetData().Count;
var root = new Node(new Rectangle(pointMin, pointMax, fileReader.GetData()), null, null);
var kdTree = new KdTreeBuilder(root);
kdTree.BuildKd(root, pointsQuantity, 2);
sw.Stop();
Console.WriteLine($"Elapsed time: {sw.Elapsed}");