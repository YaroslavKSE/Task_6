namespace Task_6;

public class KdTreeBuilder
{
    private Node _node;

    public KdTreeBuilder(Node node)
    {
        _node = node;
    }

    public Node BuildKd(Node root, int pointsQuantity, int dimension)
    {
        var dataLeft = new Dictionary<Point, string>();
        var dataRight = new Dictionary<Point, string>();
        if (pointsQuantity <= 100)
        {
            return root;
        }

        if (EvenOrOdd(dimension) == "even")
        {
            var median = root.GetRect().FindLatMedian();
            foreach (var point in root.GetRect().GetData())
            {
                if (point.Key.GetLatitude() >= median)
                {
                    dataRight.Add(point.Key, point.Value);
                }

                if (point.Key.GetLatitude() < median)
                {
                    dataLeft.Add(point.Key, point.Value);
                }
            }
        }

        if (EvenOrOdd(dimension) == "odd")
        {
            var median = root.GetRect().FindLongMedian();
            foreach (var point in root.GetRect().GetData())
            {
                if (point.Key.GetLongitude() >= median)
                {
                    dataRight.Add(point.Key, point.Value);
                }

                if (point.Key.GetLongitude() < median)
                {
                    dataLeft.Add(point.Key, point.Value);
                }
            }
        }

        root.Left = new Node(new Rectangle(FindMinCoords(dataLeft), FindMaxCoords(dataLeft), dataLeft), null, null);
        root.Right = new Node(new Rectangle(FindMinCoords(dataRight), FindMaxCoords(dataRight), dataRight), null, null);
        var leftPoints = root.Left.GetRect().GetData().Count;
        var rightPoints = root.Right.GetRect().GetData().Count;
        BuildKd(root.Left, leftPoints, dimension + 1);
        BuildKd(root.Right, rightPoints, dimension + 1);
        return root;
    }

    private Point FindMinCoords(Dictionary<Point, string> data)
    {
        double minLong = 1000;
        double minLat = 1000;
        foreach (var point in data)
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

    private Point FindMaxCoords(Dictionary<Point, string> data)
    {
        double maxLong = 0;
        double maxLat = 0;
        foreach (var point in data)
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

    private string EvenOrOdd(int number)
    {
        if (number % 2 == 0)
        {
            return "even";
        }

        return "odd";
    }
}