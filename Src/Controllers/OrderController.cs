using GFTGrovelorDeveloperCodeChallenge.Domain.Entities;
using GFTGrovelorDeveloperCodeChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GFTGrovelorDeveloperCodeChallenge.Controllers;

[Route("api/orders")]
public class OrderController(IOrdersService service, IDishesServices dishesServices) : ControllerEntityBase
{
    private readonly IOrdersService _service = service;
    private readonly IDishesServices _dishesService = dishesServices;

    [HttpPost("v1/getOrders")]
    public IActionResult GetOrders(
            [FromBody] string unparsedOrder
        )
    {
        Order order = _service.ParseOrder(unparsedOrder);
        List<Dish> dishesList = _dishesService.GetDishesList(order);
        string dishesFormatted = _service.FormatOrder(dishesList);
        
        return StatusCode(
            200, 
            new
            {
                results = dishesFormatted
            }
            );
    }
}