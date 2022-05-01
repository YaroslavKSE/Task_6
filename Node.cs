namespace Task_6;

public class Node
{
    public Node(Rectangle rectangle, Node left, Node right)
    {
        Rectangle = rectangle;
        Left = left;
        Right = right;
    }

    public Node Left { get; set; }
    public Node Right { get; set; }
    private Rectangle Rectangle { get; set; }

    public Rectangle GetRect()
    {
        return Rectangle;
    }
}