using Task_6;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var point = new Point(50.60659, 30.45436);
// point.Print();
// point.Print();
//var fileReader = new FileReader(@"D:\C#\Task_6\map.txt", new Dictionary<Point, string>());
var fileReader = new FileReader(new Dictionary<Point, string>(), "map.txt");
fileReader.ReadFile();

fileReader.SearchForPlaces(new Point(48.46079, 38.82552),5);
