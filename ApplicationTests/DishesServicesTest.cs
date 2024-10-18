using GFTGrovelorDeveloperCodeChallenge.Domain.Entities;
using GFTGrovelorDeveloperCodeChallenge.Services;

namespace ApplicationTests;

public class DishesServicesTest
{
    private readonly DishesServices _sut = new();
    
    public static IEnumerable<object[]> SuccesfullOrdersToBeAddedToListData()
    {
        yield return new object[]
        {
            new Order(
                "morning", ["1"]
            ),
            new List<Dish> {new MorningDish("egg", 1) },
        };
        yield return new object[]
        {
            new Order(
                "morning", ["1", "2", "3"]
            ),
            new List<Dish> {new MorningDish("egg", 1), new MorningDish("toast", 1), new MorningDish("coffee", 1) },
        };
        yield return new object[]
        {
            new Order(
                "evening", ["1", "2", "3", "4"]
            ),
            new List<Dish> {new EveningDish("steak", 1), new EveningDish("potato", 1), new EveningDish("wine", 1), new EveningDish("cake", 1) },
        };
        yield return new object[]
        {
            new Order(
                "evening", ["1", "2", "2", "4"]
            ),
            new List<Dish> {new EveningDish("steak", 1), new EveningDish("potato", 2), new EveningDish("cake", 1) },
        };
    }

    [Theory(DisplayName = "Should return dishes list from order entity")]
    [MemberData(nameof(SuccesfullOrdersToBeAddedToListData))]
    public void DishesService_GetDishesList_Successfull(Order order, List<Dish> expected)
    {
        var result = _sut.GetDishesList(order);
        
        Assert.Equal(expected, result);
    }
}