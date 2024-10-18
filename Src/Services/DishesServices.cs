using GFTGrovelorDeveloperCodeChallenge.Domain.Entities;
using GFTGrovelorDeveloperCodeChallenge.Services.Interfaces;

namespace GFTGrovelorDeveloperCodeChallenge.Services;

public class DishesServices : IDishesServices
{
    public List<Dish> GetDishesList(Order order)
    {
        var dishesList = new List<Dish>();
        order.Dishes.Sort();
        
        foreach (var dishId in order.Dishes)
        {
            AddOrderToList(dishId, order.DaytimeOrderCategory, dishesList);
        }
        
        return dishesList;
    }

    private void AddOrderToList(int dishId, string daytimeCategory, List<Dish> returnValue)
    {
        string orderName = daytimeCategory == "morning" ? GetMorningDishesById(dishId) : GetNightDishesById(dishId);
        
        var existingOrder = returnValue.SingleOrDefault(x => x.DishName == orderName);
        if (existingOrder == null)
        {
            returnValue.Add(new Dish
            {
                DishName = orderName,
                Count = 1
            });
        } else if (IsMultipleAllowed(dishId, daytimeCategory))
        {
            existingOrder.Count++;
        }
        else
        {
            throw new ApplicationException(string.Format("Multiple {0}(s) not allowed", orderName));
        }
    }


    private string GetMorningDishesById(int dishId)
    {
        string daytimeDishName = dishId switch
        {
            1 => "egg",
            2 => "toast",
            3 => "coffee",
            _ => throw new ApplicationException("error")
        };
        
        return daytimeDishName;
    }
    
    private string GetNightDishesById(int dishId)
    {
        string daytimeDishName = dishId switch
        {
            1 => "steak",
            2 => "potato",
            3 => "wine",
            4 => "cake",
            _ => throw new ApplicationException("error")
        };
        
        return daytimeDishName;
    }
    
    private bool IsMultipleAllowed(int dishId, string daytimeCategory)
    {
        if (daytimeCategory == "morning")
        {
            return dishId switch
            {
                3 => true,
                _ => false
            };
        }

        return dishId switch
        {
            2 => true,
            _ => false
        };
    }
}