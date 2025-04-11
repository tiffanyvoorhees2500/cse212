public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (value == Data)
            return; // No duplicates allowed
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 1
        if (value == Data)
            return true; // No duplicates allowed
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                return false;
            else
                return Left.Contains(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                return false;
            else
                return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4
       if(Left is null && Right is null)
            return 1; // Leaf node
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;
        return Math.Max(leftHeight, rightHeight) + 1;
            
    }
}