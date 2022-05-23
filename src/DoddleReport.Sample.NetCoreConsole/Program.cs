using DoddleReport;
using DoddleReport.Writers;

// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


var products = GetAll();

var report = new Report(products.ToReportSource());
var totalProducts = products.Count();
var totalOrders = products.Sum(p => p.OrderCount);

// Customize the Text Fields
report.TextFields.Title = "Products Report";
report.TextFields.SubTitle = "This is a sample report showing how Doddle Report works";
report.TextFields.Footer = "Copyright 2011 &copy; The Doddle Project";
report.TextFields.Header = string.Format(@"
    Report Generated: {0}
    Total Products: {1}
    Total Orders: {2}
    Total Sales: {3:c}", DateTime.Now, totalProducts, totalOrders, totalProducts * totalOrders);


// Render hints allow you to pass additional hints to the reports as they are being rendered
report.RenderHints.BooleanCheckboxes = true;


// Customize the data fields
report.DataFields["Id"].Hidden = true;
report.DataFields["Price"].DataFormatString = "{0:c}";
report.DataFields["LastPurchase"].DataFormatString = "{0:d}";

var writer = new HtmlReportWriter();
using var outputStream = System.IO.File.Create("c:\\temp\\test.html");

writer.WriteReport(report, outputStream);

Console.WriteLine("Done!");
Console.ReadLine();

static List<Product> GetAll()
{
    var rand = new Random();
    return Enumerable.Range(1, 1000)
        .Select(i => new Product
        {
            Id = i,
            Name = "Product " + i,
            Description = "Some random lines of text",
            Price = rand.NextDouble() * 100,
            OrderCount = rand.Next(1000),
            LastPurchase = DateTime.Now.AddDays(rand.Next(1000)),
            UnitsInStock = rand.Next(0, 2000)
        })
        .ToList();
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int OrderCount { get; set; }
    public DateTime? LastPurchase { get; set; }
    public int UnitsInStock { get; set; }
    public bool? LowStock
    {
        get { return UnitsInStock < 300; }
    }
}