namespace Task_6;

public class Node
{
    public Node(Rectangle rectangle, Node left, Node right)
    {
        _rectangle = rectangle;
        Left = left;
        Right = right;
    }
    
    public Node Left { get; set; }
    public Node Right { get; set; }
    private Rectangle _rectangle { get; set; }

    public Rectangle GetRect()
    {
        return _rectangle;
    }
}