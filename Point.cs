namespace Task_6;

public class Point
{
    private double Latitude { get; } // широта
    private double Longitude { get; } // довгота

    private const int EarthRadius = 6371;

    public Point(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public override string ToString()
    {
        return $"Long {Latitude} Lat {Longitude}";
    }

    public bool CalculateHaversine(Point pointSecond, double radius)
    {
        double lat1 = Latitude * Math.PI / 180;
        double lat2 = pointSecond.Latitude * Math.PI / 180;
        double subLat = (lat2 - lat1) * Math.PI / 180;
        double subLong = (Longitude - pointSecond.Longitude) * Math.PI / 180;
        double a = Math.Sin(subLat / 2) * Math.Sin(subLat / 2) +
                   Math.Cos(lat1) * Math.Cos(lat2) * Math.Sin(subLong / 2) * Math.Sin(subLat / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return EarthRadius * c < radius;
    }

    public double GetLongitude()
    {
        return Longitude;
    }

    public double GetLatitude()
    {
        return Latitude;
    }
}