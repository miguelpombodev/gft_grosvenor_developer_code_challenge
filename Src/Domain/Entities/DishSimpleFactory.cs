namespace GFTGrovelorDeveloperCodeChallenge.Domain.Entities;

public class DishSimpleFactory
{
    public static DishFactoryMethod GetDishFactory(string daytime)
    {
        DishFactoryMethod dishFactoryMethod = daytime switch
        {
            "morning" => new MorningDishesFactory(),
            "evening" => new EveningDishesFactory(),
            _ => throw new ApplicationException("error")
        };
            
        return dishFactoryMethod;
    }
}