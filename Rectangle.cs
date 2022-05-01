namespace Task_6;

public class Rectangle
{
    public Rectangle(Point minCoords, Point maxCoords, Dictionary<Point, string> data)
    {
        MinCoords = minCoords;
        MaxCoords = maxCoords;
        _data = data;
    }

    private Point MinCoords { get; }
    private Point MaxCoords { get; }

    private readonly Dictionary<Point, string> _data;

    public double FindLatMedian()
    {
        var listOfLats = new List<double>();
        foreach (var point in _data)
        {
            listOfLats.Add(point.Key.GetLatitude());
        }

        listOfLats.Sort();
        var median = listOfLats[listOfLats.Count / 2];
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
        var median = longs[longs.Count / 2];
        return median;
    }

    public Dictionary<Point, string> GetData()
    {
        return _data;
    }
}