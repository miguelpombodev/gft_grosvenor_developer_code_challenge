using GFTGrovelorDeveloperCodeChallenge.Domain.Entities;
using GFTGrovelorDeveloperCodeChallenge.Services.Interfaces;

namespace GFTGrovelorDeveloperCodeChallenge.Services;

public class DishesServices : IDishesServices
{
    public List<Dish> GetDishesList(Order order)
    {
        var dishesList = new List<Dish>();
        foreach (var dishId in order.Dishes)
        {
            AddOrderToList(dishId, order.DaytimeOrderCategory, dishesList);
        }
        
        return dishesList;
    }

    private void AddOrderToList(int dishId, string daytimeCategory, List<Dish> returnValue)
    {
        DishFactoryMethod dishFactoryMethod = DishSimpleFactory.GetDishFactory(daytimeCategory);
        
        Dish dish = dishFactoryMethod.Create(dishId);
        
        var existingOrder = returnValue.SingleOrDefault(x => x.DishName == dish.DishName);
        if (existingOrder == null)
        {
            dish.Count = 1;
            returnValue.Add(dish);
        } else if (dish.IsMultipleAllowed(dishId))
        {
            existingOrder.Count++;
        }
        else
        {
            throw new ApplicationException(string.Format("Multiple {0}(s) not allowed", dish.DishName));
        }
    }
    
}