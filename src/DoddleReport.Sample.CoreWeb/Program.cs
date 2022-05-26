using DoddleReport.Web;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

DoddleReport.Configuration.Config.Report.Writers.Add(
    new DoddleReport.Configuration.WriterElement
    {
        Writer = new DoddleReport.OpenXml.ExcelReportWriter(),
        FileExtension = ".xlsx",
        ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        OfferDownload = true
    });

DoddleReport.Configuration.Config.Report.Writers.Add(
    new DoddleReport.Configuration.WriterElement
    {
        Writer = new DoddleReport.iTextSharp.PdfReportWriter(),
        FileExtension = ".pdf",
        ContentType = "application/pdf",
        OfferDownload = true
    });

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapReportingRoute();
app.MapReportingRouteWithAreaSupport();

app.Run();
