using GFTGrovelorDeveloperCodeChallenge.Domain.Interfaces;

namespace GFTGrovelorDeveloperCodeChallenge.Domain.Entities;

public abstract class Dish
{
    public string DishName { get; set; }
    public int Count { get; set; }
    public abstract bool IsMultipleAllowed(int dishId);
}