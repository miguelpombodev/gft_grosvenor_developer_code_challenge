namespace GFTGrovelorDeveloperCodeChallenge.Domain.Entities;

public class MorningDishesFactory : DishFactoryMethod
{
    public override Dish Create(int dishId)
    {
        string daytimeDishName = dishId switch
        {
            1 => "egg",
            2 => "toast",
            3 => "coffee",
            _ => throw new ApplicationException("error")
        };
        
        return new MorningDish(daytimeDishName);
    }
}