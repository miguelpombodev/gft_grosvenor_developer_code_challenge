using GFTGrovelorDeveloperCodeChallenge.Domain.Entities;

namespace GFTGrovelorDeveloperCodeChallenge.Services.Interfaces;

public interface IOrdersService
{
    Order ParseOrder(string unparsedOrder);
    string FormatOrder(List<Dish> dishes);
}