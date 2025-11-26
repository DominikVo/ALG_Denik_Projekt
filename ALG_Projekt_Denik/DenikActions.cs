// csharp
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

        DateTime parsedDate;
        Console.WriteLine("Zadejte datum: (dd/MM/yyyy) nebo ponechte prázdné pro dnešní datum:");
        string input = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(input))
        {
            parsedDate = DateTime.Now;
        }
        else
        {
            string[] format = {"dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd-MM-yyyy", "d-M-yyyy"};
            while (!DateTime.TryParseExact(input, format, null, System.Globalization.DateTimeStyles.None, out parsedDate))
            {
                Console.WriteLine("Neplatný formát data. Zadejte prosím znovu datum (dd/MM/yyyy) nebo ponechte prázdné pro dnešní datum:");
                input = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(input))
                {
                    parsedDate = DateTime.Now;
                    break;
                }
            }
        }

        Data data = new Data(content, parsedDate);
        // insert after current node (or create head / append if CurrentNode is null)
        Node newNode = Program.DefaultDenik.InsertAfter(Program.CurrentNode, data);
        Program.CurrentNode = newNode;
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
            Console.WriteLine("Chcete smazat tuto stránku\n>");
            if (Console.ReadKey().Key == ConsoleKey.Delete)
            {
                Node nodeToRemove = Program.CurrentNode;
                Program.CurrentNode = nodeToRemove.Previous ?? nodeToRemove.Next;
                Program.DefaultDenik.Remove(nodeToRemove.Data);
                Console.WriteLine("Záznam byl smazán.");    
            }
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
