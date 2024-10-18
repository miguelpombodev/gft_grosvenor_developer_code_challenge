using GFTGrovelorDeveloperCodeChallenge.Domain.Entities;
using GFTGrovelorDeveloperCodeChallenge.Services;

namespace ApplicationTests;

public class OrdersServicesTest
{
    private readonly OrdersService _sut = new();

    public static IEnumerable<object[]> SuccesfullOrdersData()
    {
        yield return new object[]
        {
            "morning,1",
            new Order(
                "morning", ["1"]
            )
        };
        yield return new object[]
        {
            "Morning, 1, 2, 3",
            new Order(
                "morning", ["1", "2", "3"]
            )
        };
        yield return new object[]
        {
            "evening,1, 2, 3, 4",
            new Order(
                "evening", ["1", "2", "3", "4"]
            )
        };
        yield return new object[]
        {
            "Evening,1, 2, 2, 4",
            new Order(
                "evening", ["1", "2", "2", "4"]
            )
        };
    }

    public static IEnumerable<object[]> SuccessfullDishesList()
    {
        yield return new object[]
        {
            new List<Dish> {new MorningDish("egg"), new MorningDish("coffee"), new MorningDish("toast"), },
            "egg,coffee,toast",
        };
        yield return new object[]
        {
            new List<Dish> {new MorningDish("egg"), new MorningDish("coffee", 2) },
            "egg,coffee(x2)",
        };
        yield return new object[]
        {
            new List<Dish> {new MorningDish("coffee"), new MorningDish("toast"), },
            "coffee,toast",
        };
        yield return new object[]
        {
            new List<Dish> {new MorningDish("coffee", 3) },
            "coffee(x3)"
        };
        
        yield return new object[]
        {
            new List<Dish> {new MorningDish("egg"), new MorningDish("coffee") },
            "egg,coffee",
        };
    }


    [Theory(DisplayName = "Should return successfull orders data")]
    [MemberData(nameof(SuccesfullOrdersData))]
    public void OrderService_ParseOrders_Success(string unparsedOrder, Order expected)
    {
        var result = _sut.ParseOrder(unparsedOrder);
        
        Assert.Equal(expected, result);
    }

    [Theory(DisplayName = "Should return failure orders data that have no dishes")]
    [InlineData("morning")]
    [InlineData("evening")]
    public void OrderService_TryParseOrders_WithNoDishesIds_Fail(string unparsedOrder)
    {
        Assert.Throws<ApplicationException>(() => _sut.ParseOrder(unparsedOrder));
    }

    [Theory(DisplayName = "Should return successfull orders in form of string, with all nominal dishes")]
    [MemberData(nameof(SuccessfullDishesList))]
    public void OrdersService_FormatOrders_Success(List<Dish> dishesList, string expectedFormattedOrder)
    {
        var result = _sut.FormatOrder(dishesList);
        
        Assert.Equal(expectedFormattedOrder, result);
    }
}