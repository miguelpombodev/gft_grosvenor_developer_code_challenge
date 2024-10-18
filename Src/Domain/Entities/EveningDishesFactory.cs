namespace GFTGrovelorDeveloperCodeChallenge.Domain.Entities;

public class EveningDishesFactory : DishFactoryMethod
{
    public override Dish Create(int dishId)
    {
        string daytimeDishName = dishId switch
        {
            1 => "steak",
            2 => "potato",
            3 => "wine",
            4 => "cake",
            _ => throw new ApplicationException("error")
        };
        
        return new EveningDish(daytimeDishName);
    }
}