namespace SalesReportFeature.Models;

public class SalesData
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Product { get; set; } = "";
    public decimal Amount { get; set; }
}
