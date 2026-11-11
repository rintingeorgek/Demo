namespace Plant360.Core.Services;

/// <summary>
/// Calculates a simple monthly electricity bill for a plant.
/// </summary>
public class BillingCalculator
{
    public const decimal FixedCharge = 50m;
    public const decimal RatePerUnit = 6.5m;

    public decimal CalculateMonthlyBill(decimal unitsConsumed)
    {
        if (unitsConsumed < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(unitsConsumed), "Units consumed cannot be negative.");
        }

        return FixedCharge + (unitsConsumed * RatePerUnit);
    }
}
