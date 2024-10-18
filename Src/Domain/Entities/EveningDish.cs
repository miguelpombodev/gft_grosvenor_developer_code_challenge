namespace GFTGrovelorDeveloperCodeChallenge.Domain.Entities;

public class EveningDish : Dish
{
    public EveningDish(string dishName)
    {
        DishName = dishName;
        Count = 0;
    }

    public override bool IsMultipleAllowed(int dishId)
    {
        return dishId switch
        {
            2 => true,
            _ => false
        };
    }
}