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
        double median = 0;
        foreach (var point in _data)
        {

        }

        return 0;
    }
}