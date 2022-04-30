
namespace Task_6;

public class Point
{
    private double _latitude { get; } // широта
    private double _longitude { get; } // довгота
    
    private const int EarthRadius = 6371;

    public Point(double latitude, double longitude)
    {
        _latitude = latitude;
        _longitude = longitude;
    }

    public override string ToString()
    {
        return $"Long {_latitude} Lat {_longitude}";
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
        return EarthRadius * c  < radius;
    }

    public double GetLongitude()
    {
        return _longitude;
    }
    public double GetLatitude()
    {
        return _latitude;
    }
}