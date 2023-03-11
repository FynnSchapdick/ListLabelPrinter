namespace ListLabelPrinter.Api.Infrastructure.Configuration;

public sealed class ListLabelLogOptions
{
    public bool EnablePrinterInformation { get; set; }
    public bool EnableDataProvider { get; set; }
    public bool EnableLicensing { get; set; }
    public bool EnableDotNetComponent { get; set; }
    public bool EnableApiCalls { get; set; }
    public bool EnableOther { get; set; }
}