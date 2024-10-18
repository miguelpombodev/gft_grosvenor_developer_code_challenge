namespace GFTGrovelorDeveloperCodeChallenge.Domain.Entities;

public class MorningDish : Dish
{
    public MorningDish(string dishName)
    {
        DishName = dishName;
        Count = 0;
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