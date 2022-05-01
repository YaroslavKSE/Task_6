namespace Task_6;

public class FileReader
{
    private readonly string _path;
    private readonly Dictionary<Point, string> _data;

    public FileReader(string path, Dictionary<Point, string> dictionary)
    {
        _path = path;
        _data = dictionary;
    }

    public void ReadFile()
    {
        var file = File.ReadAllLines(_path);
        foreach (var line in file)
        {
            var splitedLine = line.Split(";");
            if (splitedLine.Length < 3)
            {
                continue;
            }

            var point = new Point(double.Parse(splitedLine[0]), double.Parse(splitedLine[1]));
            var n = splitedLine.Length - 1;
            var place = splitedLine[n - 2];
            if (place == "")
            {
                continue;
            }

            _data.Add(point, place);
        }
    }

    public void SearchForPlaces(Point point, int radius)
    {
        foreach (var VARIABLE in _data)
        {
            var inside = point.CalculateHaversine(VARIABLE.Key, radius);
            if (inside)
            {
                if (VARIABLE.Value == "")
                {
                    continue;
                }

                Console.WriteLine(VARIABLE.Key);
                Console.WriteLine(VARIABLE.Value);
            }
        }
    }

    public Dictionary<Point, string> GetData()
    {
        return _data;
    }

    public Point FindMinCoords()
    {
        double minLong = 1000;
        double minLat = 1000;
        foreach (var point in _data)
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

    public Point FindMaxCoords()
    {
        double maxLong = 0;
        double maxLat = 0;
        foreach (var point in _data)
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
}