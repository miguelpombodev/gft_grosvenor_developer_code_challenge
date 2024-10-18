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
}