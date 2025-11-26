// csharp
namespace ALG_Projekt_Denik;

public class LinkList
{
    private Node? Item;
    private int Count;

    public LinkList()
    {
        Item = null;
        Count = 0;
    }

    public void Add(Data data)
    {
        Node newNode = new Node(data);
        if (Item == null)
        {
            Item = newNode;
        }
        else
        {
            Node current = Item;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            newNode.Previous = current;
        }
        Count++;
    }
    
    public Node InsertAfter(Node? after, Data data)
    {
        Node newNode = new Node(data);

        if (Item == null)
        {
            Item = newNode;
        }
        else if (after == null)
        {
            Node current = Item;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            newNode.Previous = current;
        }
        else
        {
            newNode.Next = after.Next;
            newNode.Previous = after;
            after.Next = newNode;
            if (newNode.Next != null)
            {
                newNode.Next.Previous = newNode;
            }
        }

        Count++;
        return newNode;
    }

    public void Remove(Data data)
    {
        if(Item == null) return;


        if (Item.Data.Equals(data))
        {
            Item = Item.Next;
            if (Item != null)
            {
                Item.Previous = null;
            }
            Count--;
            return;
        }

        Node? current = Item;
        while (current?.Next != null)
        {
            if (current.Next.Data.Equals(data))
            {
                current.Next = current.Next.Next;
                if (current.Next != null)
                {
                    current.Next.Previous = current;
                }
                Count--;
                return;
            }
            current = current.Next;
        }
    }

    public void PrintPage(Node? Item = null)
    {
        if (Item == null)
        {
            return;
        }
        Console.WriteLine("Datum: ");
        Console.WriteLine(Item.Data.Timestamp.ToString("dd.MM.yyyy"));
        Console.WriteLine();
        Console.WriteLine("Text: ");
        Console.WriteLine(Item.Data.Content);
    }

    public Node? GetFirstNode()
    {
        return Item;
    }

    public Node? GetLastNode()
    {
        if (Item == null)
        {
            return null;
        }

        Node current = Item;
        while (current.Next != null)
        {
            current = current.Next;
        }
        return current;
    }

    public int GetCount()
    {
        return Count;
    }
}
