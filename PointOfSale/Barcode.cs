namespace PointOfSale;

public class Barcode
{
    public decimal Total { get; private set; } = 0;

    public string Scan(string code)
    {
        switch (code)
        {
            case "99999":
                return "Error: barcode not found";
            case "":
                return "Error: empty barcode";
        }

        var dollar = code switch
        {
            "12345" => (decimal)7.25,
            "23456" => (decimal)12.5,
            _ => 0
        };
        Total += dollar;

        return $"${dollar:.00}";
    }
}