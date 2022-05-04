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
var rect = new Rectangle(pointMin, pointMax, fileReader.GetData());
var res = rect.DescribeCircle(pointMin, 100, 45);
var res2 = rect.DescribeCircle(pointMin, 100, 225);
var rect1 = new Rectangle(new Point(10, 0), new Point(0, 10),
    new Dictionary<Point, string>()); 
var rect2 = new Rectangle(new Point(15, 0), new Point(5, 5), new Dictionary<Point, string>());
Console.WriteLine(rect1.DoRectsOverlap(rect2));
var pointsQuantity = fileReader.GetData().Count;
var root = new Node(new Rectangle(pointMin, pointMax, fileReader.GetData()), null, null);
var kdTree = new KdTreeBuilder(root);
kdTree.BuildKd(root, pointsQuantity, 2);
sw.Stop();
Console.WriteLine($"Elapsed time: {sw.Elapsed}");