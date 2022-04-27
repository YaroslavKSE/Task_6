using System.Runtime.InteropServices;

namespace Task_6;

public class Point
{
    private readonly float _longitude;
    private readonly float _latitude;

    public Point(float longitude, float latitude)
    {
        _longitude = longitude;
        _latitude = latitude;
    }

    public void Print()
    {
        Console.Write(_longitude.ToString()); Console.Write(" "); Console.WriteLine(_latitude);
    }
}