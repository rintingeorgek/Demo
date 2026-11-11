using Plant360.Core.Services;

namespace Plant360.Tests;

public class BillingCalculatorTests
{
    [Theory]
    [InlineData(0, 50)]
    [InlineData(100, 700)]
    [InlineData(250, 1675)]
    public void CalculateMonthlyBill_ReturnsFixedChargePlusUsage(decimal units, decimal expected)
    {
        var calculator = new BillingCalculator();

        var bill = calculator.CalculateMonthlyBill(units);

        Assert.Equal(expected, bill);
    }

    [Fact]
    public void CalculateMonthlyBill_NegativeUnits_Throws()
    {
        var calculator = new BillingCalculator();

        Assert.Throws<ArgumentOutOfRangeException>(() => calculator.CalculateMonthlyBill(-1));
    }
}
