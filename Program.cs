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
var pointsQuantity = fileReader.GetData().Count;
var root = new Node(new Rectangle(pointMin, pointMax, fileReader.GetData()), null, null);
var res1 = root.GetRect().FindLatMedian();
var res2 = root.GetRect().FindLongMedian();
Console.WriteLine();

// void BuildKd(Node root, int pointsQuantity)
// {
//     // if (EvenOrOdd(changeSplit) == "even")
//     // {
//     //     root.Left = BuildKd()
//     // }
//     if (pointsQuantity <= 100)
//     {
//         return;
//     }
//
//     while (pointsQuantity <= 100)
//     {
//         var median = root.GetRect().FindLatMedian();
//         var dataLeft = new Dictionary<Point, string>();
//         var dataRight = new Dictionary<Point, string>();
//         foreach (var point in root.GetRect().GetData())
//         {
//             if (point.Key.GetLatitude() > median)
//             {
//                 dataRight.Add(point.Key, point.Value);
//             }
//
//             if (point.Key.GetLatitude() < median)
//             {
//                 dataLeft.Add(point.Key, point.Value);
//             }
//         }
//         root.Left = new Node(new Rectangle(FindMinCoords(dataLeft), FindMaxCoords(dataLeft), dataLeft), null, null);
//         root.Right = new Node(new Rectangle(FindMinCoords(dataRight), FindMaxCoords(dataRight), dataRight), null, null);
//         var leftPoints = root.Left.GetRect().GetData().Count;
//         var rightPoints = root.Right.GetRect().GetData().Count;
//     }
// }
//
// BuildKd(root, pointsQuantity);


Point FindMinCoords(Dictionary<Point, string> data)
{
    double minLong = 1000;
    double minLat = 1000;
    foreach (var point in data)
    {
        if (point.Key.GetLongitude() < minLong)
        {
            minLong = point.Key.GetLongitude();
        } 
        if (point.Key.GetLatitude() < minLat)
        {
            minLat = point.Key.GetLatitude();
        } 
    }

    return new Point(minLat, minLong);
}

Point FindMaxCoords(Dictionary<Point, string> data)
{
    double maxLong = 0;
    double maxLat = 0;
    foreach (var point in data)
    {
        if (point.Key.GetLongitude() > maxLong)
        {
            maxLong = point.Key.GetLongitude();
        } 
        if (point.Key.GetLatitude() > maxLat)
        {
            maxLat = point.Key.GetLatitude();
        } 
    }

    return new Point(maxLat, maxLong);
}

string EvenOrOdd(int number)
{
    if (number % 2 == 0)
    {
        return "even";
    }
    return "odd";
}
