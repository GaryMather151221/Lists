namespace Lists
{
    public interface INode
    {
        INode NextNode { get; set; }
        INode PrevNode { get; set; }
        string Value { get; set; }
    }
}