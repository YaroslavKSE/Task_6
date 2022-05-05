namespace Task_6;

public class KdTreeSearcher
{
    private readonly Node tree;
    private Rectangle _rectangleToSearch;

    public KdTreeSearcher(Node tree, Rectangle rectangleToSearch)
    {
        this.tree = tree;
        this._rectangleToSearch = rectangleToSearch;
    }

    public void Search(Point centre, double radius)
    {
        if (!tree.GetRect().DoRectsOverlap(_rectangleToSearch))
        {
            if (tree.Left == null)
            {
                new FileReader(tree.GetRect().GetData()).SearchForPlaces(centre, radius);
                
            }
            else
            {
                new KdTreeSearcher(tree.Left, _rectangleToSearch).Search(centre, radius);
                new KdTreeSearcher(tree.Right, _rectangleToSearch).Search(centre, radius);
            }
        }
    }
}