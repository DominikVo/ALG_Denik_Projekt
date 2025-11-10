namespace ALG_Projekt_Denik;

public class Data
{
    public string Content { get; set; }
    public DateTime Timestamp { get; set; }
    
    public Data(string content, DateTime timestamp)
    {
        Content = content;
        Timestamp = timestamp;
    }
}