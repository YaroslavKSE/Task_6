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
            if (splitedLine.Length < 3) { continue; }
            var point = new Point(float.Parse(splitedLine[0]), float.Parse(splitedLine[1]));
            var n = splitedLine.Length - 1;
            var place = splitedLine[n - 2];
            _data.Add(point, place);
        }
    }
}