using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[Binding]
public class OrderCalculationSteps
{
    private readonly ScenarioContext _context;
    private OrderService _service;
    private decimal _result;

    public OrderCalculationSteps(ScenarioContext context)
    {
        _context = context;
    }

    [Given(@"I have an order service")]
    public void GivenIHaveAnOrderService()
    {
        _service = new OrderService();
        _context["OrderService"] = _service;
    }

    [When(@"I calculate total for quantity (.*) and price (.*)")]
    public void WhenICalculateTotalForQuantityAndPrice(int quantity, decimal price)
    {
        _service = (OrderService)_context["OrderService"];
        _result = _service.CalculateTotal(quantity, price);
        _context["Result"] = _result;
    }

    [Then(@"the result should be (.*)")]
    public void ThenTheResultShouldBe(decimal expected)
    {
        _result = (decimal)_context["Result"];
        Assert.AreEqual(expected, _result);
    }
}
