using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace ALG_Projekt_Denik;

public static class FileHandler
{
    public static List<String> FilePaths = new List<string>();

    public static void SaveToFile(LinkList denik, string filePath)
    {
        List<Data> dataList = new List<Data>();
        Node? current = denik.GetFirstNode();
        while (current != null)
        {
            dataList.Add(current.Data);
            current = current.Next;
        }
        
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(dataList, options);
        File.WriteAllText(filePath, jsonString);
    }

    public static LinkList LoadFromFile(string filePath)
    {
        LinkList denik = new LinkList();
        if (!File.Exists(filePath))
        {
            return denik;
        }

        var jsonString = File.ReadAllText(filePath);
        if (string.IsNullOrWhiteSpace(jsonString))
        {
            return denik;
        }
        
        var dataList = JsonSerializer.Deserialize<List<Data>>(jsonString);

        if (dataList == null) return denik;
        
        foreach (Data data in dataList)
        {
            denik.Add(data);
        }

        return denik;
    }
    
    public static void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
    public static void PrintAllFilesInDirectory(string directoryPath)
    {
        FilePaths = Directory.GetFiles(directoryPath, "*.json", SearchOption.AllDirectories).ToList();
        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Adresář neexistuje.");
            return;
        }

        string[] files = Directory.GetFiles(directoryPath, "*.json", SearchOption.AllDirectories);
        Console.WriteLine("Soubory v adresáři:");
        foreach (string file in files)
        {
            FilePaths.Add(file);
        }
        
        foreach (string file in FilePaths)
        {
            Console.WriteLine(Path.GetFileName(file));
        }
    }
}