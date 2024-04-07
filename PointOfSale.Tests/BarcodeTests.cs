namespace PointOfSale.Tests;

public class BarcodeTests
{
    private Barcode _barcode = null!;
    
    [SetUp]
    public void Setup()
    {
        _barcode = new Barcode();
    }

    [Test]
    [TestCase("12345", "$7.25")]
    [TestCase("23456", "$12.50")]
    [TestCase("99999", "Error: barcode not found")]
    [TestCase("", "Error: empty barcode")]
    public void ReturnResult_WhenBarcodeIsValid(string code, string expected)
    {
        var result = _barcode.Scan(code);
        
        Assert.That(result, Is.EqualTo(expected));
    }
    
    [Test]
    public void AddDollarToTotal_WhenBarcodeIsValid()
    {
        _barcode.Scan("12345");
        _barcode.Scan("23456");
        
        Assert.That(_barcode.Total, Is.EqualTo(19.75));
    }
}
