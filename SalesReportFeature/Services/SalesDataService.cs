using SalesReportFeature.Models;

namespace SalesReportFeature.Services;

public class SalesDataService
{
    public List<SalesData> Sales { get; } = [];

    public SalesDataService() => Reset();

    public string? Save(Guid? id, string product, decimal amount)
    {
        product = product.Trim();
        if (product.Length == 0 || product.Length > 24)
            return "Введите название товара от 1 до 24 символов";
        if (amount < 0 || amount > 1000000)
            return "Сумма должна быть от 0 до 1 000 000 рублей";
        if (Sales.Any(item => item.Id != id && item.Product.Equals(product, StringComparison.OrdinalIgnoreCase)))
            return "Товар с таким названием уже есть";
        if (id is null && Sales.Count >= 12)
            return "На графике может быть не больше 12 товаров";

        if (id is null)
        {
            Sales.Add(new SalesData { Product = product, Amount = decimal.Round(amount, 2) });
        }
        else
        {
            var item = Sales.FirstOrDefault(item => item.Id == id);
            if (item is null) return "Товар не найден";
            item.Product = product;
            item.Amount = decimal.Round(amount, 2);
        }
        return null;
    }

    public void Delete(Guid id) => Sales.RemoveAll(item => item.Id == id);

    public void Reset()
    {
        Sales.Clear();
        Sales.AddRange([
            new SalesData { Product = "Ноутбуки", Amount = 45000 },
            new SalesData { Product = "Телефоны", Amount = 30000 },
            new SalesData { Product = "Наушники", Amount = 15000 },
            new SalesData { Product = "Мониторы", Amount = 25000 }
        ]);
    }
}
