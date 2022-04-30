using System.Security.Cryptography.X509Certificates;

namespace Task_6;

public class Rectangle
{
    public Rectangle(Point minCoords, Point maxCoords, Dictionary<Point, string> data)
    {
        _minCoords = minCoords;
        _maxCoords = maxCoords;
        _data = data;
    }
    private Point _minCoords { get; set; }
    private Point _maxCoords { get; set; }
    private readonly Dictionary<Point, string> _data;

    public double FindLatMedian()
    {
        var listOfLats = new List<double>();
        foreach (var point in _data)
        {
            listOfLats.Add(point.Key.GetLatitude());
        }
        listOfLats.Sort();
        var median  = listOfLats[listOfLats.Count / 2];
        // var dataLeft= new  Dictionary<Point, string>();
        // var dataRight = new  Dictionary<Point, string>();
        // foreach (var point in _data)
        // {
        //     if (point.Key.GetLatitude() >= median)
        //     {
        //         dataRight.Add(point.Key, point.Value);
        //     }
        //     if (point.Key.GetLatitude() < median)
        //     {
        //         dataLeft.Add(point.Key, point.Value);
        //     }
        // }
        return median;
    }
    public double FindLongMedian()
    {
        var longs = new List<double>();
        foreach (var point in _data)
        {
            longs.Add(point.Key.GetLongitude());
        }
        longs.Sort();
        var median  = longs[longs.Count / 2];
        return median;
    }

    public Dictionary<Point, string> GetData()
    {
        return _data;
    }
}