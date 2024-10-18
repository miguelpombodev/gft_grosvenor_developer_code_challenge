namespace GFTGrovelorDeveloperCodeChallenge.Domain.Entities;

public class Order
{
    
    public Order(string daytimeOrderCategory, List<string> orderedDishes)
    {
        SetDaytimeOrderCategory(daytimeOrderCategory);
        SetDishes(orderedDishes);
    }
    
    public string DaytimeOrderCategory { get; private set; } 
    public List<int> Dishes { get; private set; } = new List<int>();

    private void SetDaytimeOrderCategory(string daytimeOrderCategory)
    {
        DaytimeOrderCategory = daytimeOrderCategory switch
        {
            "morning" => "morning",
            "evening" => "evening",
            _ => throw new ApplicationException("Invalid daytime order category")
        };
    }
    
    private void SetDishes(List<string> dishes)
    {
        foreach (string daytimeDish in dishes)
        {
            if (int.TryParse(daytimeDish, out int parsedDaytimeDish))
            {
                Dishes.Add(parsedDaytimeDish);
            }
            else
            {
                throw new ApplicationException("Order needs to be comma separated list of numbers");
            }
        }
        
        Dishes.Sort();
    }
}