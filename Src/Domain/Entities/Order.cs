namespace GFTGrovelorDeveloperCodeChallenge.Domain.Entities;

public class Order
{
    
    public Order(string daytimeOrderCategory)
    {
        SetDaytimeOrderCategory(daytimeOrderCategory);
    }
    
    public string DaytimeOrderCategory { get; set; } 
    public List<int> Dishes { get; set; } = new List<int>();

    private void SetDaytimeOrderCategory(string daytimeOrderCategory)
    {
        DaytimeOrderCategory = daytimeOrderCategory switch
        {
            "morning" => "morning",
            "evening" => "evening",
            _ => throw new ArgumentException("Invalid daytime order category")
        };
    }

    private string GetDaytimeOrderCategory()
    {
        return DaytimeOrderCategory;
    }
}