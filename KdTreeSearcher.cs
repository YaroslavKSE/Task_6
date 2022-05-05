namespace Task_6;

public class KdTreeSearcher
{
    private Node tree;
    private Rectangle rectangleToSearch;

    public KdTreeSearcher(Node tree, Rectangle rectangleToSearch)
    {
        this.tree = tree;
        this.rectangleToSearch = rectangleToSearch;
    }

    public void Search(Point centre, int radius)
    {
        if (tree.GetRect().DoRectsOverlap(rectangleToSearch))
        {
            if (tree.Left == null)
            {
                foreach (var place in tree.GetRect().GetData())
                {
                    new FileReader(tree.GetRect().GetData()).SearchForPlaces(centre, radius);
                }
            }
            else
            {
                new KdTreeSearcher(tree.Left, rectangleToSearch).Search(centre, radius);
                new KdTreeSearcher(tree.Right, rectangleToSearch).Search(centre, radius);
            }
        }
    }
}