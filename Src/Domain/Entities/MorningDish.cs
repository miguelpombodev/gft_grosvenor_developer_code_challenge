namespace GFTGrovelorDeveloperCodeChallenge.Domain.Entities;

public class MorningDish : Dish
{
    public MorningDish(string dishName, int count = 0)
    {
        DishName = dishName;
        Count = count;
    }

    public override bool IsMultipleAllowed(int dishId)
    {
        return dishId switch
        {
            3 => true,
            _ => false
        };
    }
}