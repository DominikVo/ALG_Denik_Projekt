namespace ALG_Projekt_Denik;

enum Mode
{
    VIEWEntry,
    VIEWDeniks
}

class Program
{
    public static bool Running = true;
    public static LinkList DefaultDenik = new LinkList();
    public static Node? CurrentNode = null;
    private static string Action = "";
    private const string FilePath = "denik.json";
    
    private static void Main()
    {
        DefaultDenik = FileHandler.LoadFromFile(FilePath);
        CurrentNode = DefaultDenik.GetFirstNode();
        
        while (Running)
        {
            Console.WriteLine("-----------------");
            ShowMenu();
            Console.WriteLine("-----------------");
            if (CurrentNode != null)
            {
                DefaultDenik.PrintPage(CurrentNode);
            }
            else
            {
                Console.WriteLine("Deník je prázdný.");
            }
            Console.WriteLine("-----------------");
            Console.WriteLine("> ");
            Action = Console.ReadLine() ?? "";
            ActionUse(Action);
            Console.WriteLine();
            Clear();
        }
        
        FileHandler.SaveToFile(DefaultDenik, FilePath);
    }

    private static void ShowMenu()
    {
        Console.WriteLine("Deník se ovládá následujícími příkazy:");
        Console.WriteLine("predchozi - Přesunutí na předchozí záznam");
        Console.WriteLine("dalsi - Přesunutí na další záznam");
        Console.WriteLine("novy - Vytvoření nového záznamu");
        Console.WriteLine("uloz - Uložení aktuálního záznamu");
        Console.WriteLine("smaz - Smazání aktuálního záznamu");
        Console.WriteLine("zavri - Zavření aktuálního deníku");
        Console.WriteLine();
        Console.WriteLine("Počet záznamů v deníku: " + DefaultDenik.GetCount()); 
    }

    private static void ActionUse(String action)
    { 
        switch (action)
        {
            case "predchozi":
                DenikActions.PreviousEntry();
                break;
            case "dalsi":
                DenikActions.NextEntry();
                break;
            case "novy":
                DenikActions.NewEntry();
                break;
            case "uloz":
                DenikActions.SaveEntry();
                break;
            case "smaz":
                DenikActions.DeleteEntry();
                break;
            case "zavri":
                DenikActions.CloseDenik();
                break;
            default:
                Console.WriteLine("Neplatný příkaz!");
                break;
        }
    }

    private static void Clear()
    {
        Console.Clear();
    }

    private static void ShowDiaries()
    {
        FileHandler.PrintAllFilesInDirectory("");
    }
    
}