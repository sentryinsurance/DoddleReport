using DoddleReport;

// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


var products = GetAll();

var report = new Report(products.ToReportSource());
var totalProducts = products.Count();
var totalOrders = products.Sum(p => p.OrderCount);

// Customize the Text Fields
report.TextFields.Title = "Products Report";
report.TextFields.SubTitle = "This is a sample report showing how Doddle Report works";
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
report.DataFields["Price"].DataStyle.Width = 200;

//ProduceReport(new DoddleReport.Writers.HtmlReportWriter(), report, "c:\\temp\\doddlereportHtml.html");
//ProduceReport(new DoddleReport.Writers.ExcelReportWriter(), report, "c:\\temp\\doddlereportClassicExcel.xls");
//ProduceReport(new DoddleReport.Writers.DelimitedTextReportWriter(), report, "c:\\temp\\doddlereportDelimitedText.txt");
ProduceReport(new DoddleReport.OpenXml.ExcelReportWriter(), report, "c:\\temp\\doddlereportOpenXml.xlsx");
//ProduceReport(new DoddleReport.iTextSharp.PdfReportWriter(), report, "c:\\temp\\doddlereportPdf.pdf");

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
            Description = "Some random lines of text Some random lines of text Some random lines of text",
            Price = rand.NextDouble() * 100,
            OrderCount = rand.Next(1000),
            LastPurchase = DateTime.Now.AddDays(rand.Next(1000)),
            UnitsInStock = rand.Next(0, 2000)
        })
        .ToList();
}

static void ProduceReport(IReportWriter reportWriter, Report report, string filename)
{
    using var outputStream = System.IO.File.Create(filename);
    reportWriter.WriteReport(report, outputStream);
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