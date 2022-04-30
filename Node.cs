namespace Task_6;

public class Node
{
    public Node(Rectangle rectangle, Node left, Node right)
    {
        _rectangle = rectangle;
        Left = left;
        Right = right;
    }
    
    private Node Left { get; set; }
    private Node Right { get; set; }
    private Rectangle _rectangle { get; set; }
}