namespace Lists
{
    public interface ILinkedList
    {
        INode Top { get; set; }
        INode Find(string value);
        void Add(string value);
        bool Delete(INode node);
        string[] Values();
    }
}