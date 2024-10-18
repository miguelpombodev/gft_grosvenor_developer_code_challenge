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
    
    /// <summary>
    /// Verifies if an object is an instance of Order, if it is, its needed to compare each property 
    /// </summary>
    /// <returns>Returns a boolean showing if all properties values are equal between compared objects.</returns>
    public override bool Equals(object obj)
    {
        if (obj is not Order other)
            return false;

        return DaytimeOrderCategory == other.DaytimeOrderCategory &&
               Dishes.SequenceEqual(other.Dishes);
    }

    /// <summary>
    /// Generates a hash for the object based in its properties
    /// </summary>
    /// <returns>Returns a single hash code.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(DaytimeOrderCategory, Dishes);
    }
}