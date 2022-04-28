using System.Runtime.InteropServices;

namespace Task_6;

public class Point
{
    private readonly double _longitude;
    private readonly double _latitude;

    public Point(double longitude, double latitude)
    {
        _longitude = longitude;
        _latitude = latitude;
    }

    public void Print()
    {
        Console.Write(_longitude.ToString()); Console.Write(" "); Console.WriteLine(_latitude);
    }

    public bool CalculateHaversine(Point pointSecond, double radius)
    {
        double lat1 = _latitude * Math.PI / 180;
        double lat2 = pointSecond._latitude * Math.PI / 180;
        double subLat = (lat2 - lat1) * Math.PI / 180;
        double subLong = (_longitude - pointSecond._longitude) * Math.PI / 180;
        double a = Math.Sin(subLat / 2) * Math.Sin(subLat / 2) +
                   Math.Cos(lat1) * Math.Cos(lat2) * Math.Sin(subLong / 2) * Math.Sin(subLat / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return 6371 * c  < radius;
    }
}