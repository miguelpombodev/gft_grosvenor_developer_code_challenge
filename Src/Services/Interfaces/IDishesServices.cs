using GFTGrovelorDeveloperCodeChallenge.Domain.Entities;

namespace GFTGrovelorDeveloperCodeChallenge.Services.Interfaces;

public interface IDishesServices
{
    List<Dish> GetDishesList(Order order);
}