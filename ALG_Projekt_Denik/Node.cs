namespace ALG_Projekt_Denik;

public class Node
{
    public Data Data { get; set; }
    public Node? Previous { get; set; }
    public Node? Next { get; set; }

    public Node(Data data)
    {
        Data = data;
        Previous = null;
        Next = null;
    }
}