
using System.Diagnostics;
using Task_6;

Point centre = new Point(49.8434957584673, 24.00781313076388);
double radius = 0.6;
void Main(string[] args)
{
    centre = new Point(Convert.ToDouble(args[0]), Convert.ToDouble(args[1]));
    radius = Convert.ToDouble(args[2]);
}
Console.OutputEncoding = System.Text.Encoding.UTF8;
var fileReader = new FileReader(new Dictionary<Point, string>(), @"D:\C#\Task_6\ukraine_poi.csv");
fileReader.ReadFile();
var pointMin = fileReader.FindMinCoords();
var pointMax = fileReader.FindMaxCoords();
var root = new Node(new Rectangle(pointMin, pointMax, fileReader.GetData()), null, null);
var kdTree = new KdTreeBuilder(root);
var kd = kdTree.BuildKd(root, fileReader.GetData().Count, 2);
var rect = new Rectangle(pointMin, pointMax, fileReader.GetData());
var res = rect.DescribeCircle(centre, radius, 45);
var res2 = rect.DescribeCircle(centre, radius, 225);
Rectangle describeCircle = new Rectangle(res, res2, new Dictionary<Point, string>());
Console.WriteLine(rect.DoRectsOverlap(describeCircle));
KdTreeSearcher toSearch = new KdTreeSearcher(kd, describeCircle);
var sw = new Stopwatch();
toSearch.Search(centre, radius);
Console.WriteLine();


