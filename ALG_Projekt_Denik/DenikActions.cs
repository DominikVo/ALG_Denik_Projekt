namespace ALG_Projekt_Denik;

public static class DenikActions
{
    public static void PreviousEntry()
    {
        if (Program.CurrentNode?.Previous != null)
        {
            Program.CurrentNode = Program.CurrentNode.Previous;
        }
        else
        {
            Console.WriteLine("Nelze přejít na předchozí záznam.");
        }
    }

    public static void NextEntry()
    {
        if (Program.CurrentNode?.Next != null)
        {
            Program.CurrentNode = Program.CurrentNode.Next;
        }
        else
        {
            Console.WriteLine("Nelze přejít na další záznam.");
        }
    }

    public static void NewEntry()
    {
        Console.WriteLine("Zadejte text nového záznamu:");
        string content = Console.ReadLine() ?? "";
        Data data = new Data(content, DateTime.Now);
        Program.DefaultDenik.Add(data);
        Program.CurrentNode = Program.DefaultDenik.GetLastNode();
    }

    public static void SaveEntry()
    {
        FileHandler.SaveToFile(Program.DefaultDenik, "denik.json");
        Console.WriteLine("Deník byl uložen.");
    }

    public static void DeleteEntry()
    {
        if (Program.CurrentNode != null)
        {
            Node nodeToRemove = Program.CurrentNode;
            Program.CurrentNode = nodeToRemove.Previous ?? nodeToRemove.Next;
            Program.DefaultDenik.Remove(nodeToRemove.Data);
            Console.WriteLine("Záznam byl smazán.");
        }
        else
        {
            Console.WriteLine("Není co smazat.");
        }
    }

    public static void CloseDenik()
    {
        Program.Running = false;
        Console.WriteLine("Deník byl zavřen.");
    }
}