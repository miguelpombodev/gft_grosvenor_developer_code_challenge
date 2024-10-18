using GFTGrovelorDeveloperCodeChallenge.Domain.Entities;
using GFTGrovelorDeveloperCodeChallenge.Services.Interfaces;

namespace GFTGrovelorDeveloperCodeChallenge.Services;

public class OrdersService : IOrdersService
{
    public Order ParseOrder(string unparsedOrder)
    {
        string daytimeDishCategory = unparsedOrder.Split(',').First().ToLower();
        List<string> daytimeDishes = unparsedOrder.Split(',').Skip(1).ToList();

        var order = new Order(daytimeDishCategory);

        foreach (string daytimeDish in daytimeDishes)
        {
            if (int.TryParse(daytimeDish, out int parsedDaytimeDish))
            {
                order.Dishes.Add(parsedDaytimeDish);
            }
            else
            {
                throw new ApplicationException("Order needs to be comma separated list of numbers");
            }
        }

        return order;
    }

    public string FormatOrder(List<Dish> dishes)
    {
            var returnValue = "";

            foreach (var dish in dishes)
            {
                returnValue = returnValue + string.Format(",{0}{1}", dish.DishName, GetMultiple(dish.Count));
            }

            if (returnValue.StartsWith(","))
            {
                returnValue = returnValue.TrimStart(',');
            }

            return returnValue;
    }
    private object GetMultiple(int count)
    {
        if (count > 1)
        {
            return string.Format("(x{0})", count);
        }
        return "";
    }
}