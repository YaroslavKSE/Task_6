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

    public Point DescribeCircle(Point point, int distance, double bearingUp)
    {
        bearingUp = bearingUp * Math.PI / 180;
        var φ1 = point.GetLatitude() * Math.PI / 180;
        var λ1 = point.GetLongitude() * Math.PI / 180;
        var R = 6371.0;
        double deviation = distance / R;
        double φ2 = Math.Asin( Math.Sin(φ1)*Math.Cos(deviation) +
                               Math.Cos(φ1)*Math.Sin(deviation)*Math.Cos(bearingUp) );
        double λ2 = λ1 + Math.Atan2(Math.Sin(bearingUp)*Math.Sin(deviation)*Math.Cos(φ1),
            Math.Cos(deviation)-Math.Sin(φ1)*Math.Sin(φ2));
        var φ = φ2 * 180 / Math.PI;
        var λ = λ2 * 180 / Math.PI;
        
        return new Point(φ, λ);
    }

    public bool DoRectsOverlap(Rectangle rect)
    {
        // if (MinCoords.GetLatitude() == MaxCoords.GetLatitude() || MinCoords.GetLatitude() == MaxCoords.GetLongitude() ||
        //     rect.MinCoords.GetLatitude() == rect.MaxCoords.GetLatitude() ||
        //     rect.MinCoords.GetLongitude() == rect.MaxCoords.GetLongitude())
        // {
        //     return false;
        // }
        
        // l = MaxCoords, R = MinCoords
        if (MaxCoords.GetLatitude() >= rect.MinCoords.GetLatitude() ||
            rect.MaxCoords.GetLatitude() >= MinCoords.GetLatitude())
        {
            return false;
        }

        if (MinCoords.GetLongitude() >= rect.MaxCoords.GetLongitude() ||
            rect.MinCoords.GetLongitude() >= MaxCoords.GetLongitude())
        {
            return false;
        }

        return true;
    }
    
}