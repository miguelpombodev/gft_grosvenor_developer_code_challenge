namespace GFTGrovelorDeveloperCodeChallenge.Domain.Entities;

public class EveningDish : Dish
{
    public EveningDish(string dishName, int count = 0)
    {
        DishName = dishName;
        Count = count;
    }

    public override bool IsMultipleAllowed(int dishId)
    {
        return dishId switch
        {
            2 => true,
            _ => false
        };
    }
    
    public override bool Equals(object obj)
    {
        if (obj is not EveningDish other)
            return false;

        return Count == other.Count && DishName == other.DishName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Count, DishName);
    }
}