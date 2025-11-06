using Xunit;
// using OrderManagement.API.Controllers;

namespace OrderManagement.Test
{
    public class OrderManagementTest
    {

        [Fact]
        public void CalculateToatal()
        {
            var service = new OrderService();

            var result = 3;

            Assert.Equal(2, result);
        }
    }
}