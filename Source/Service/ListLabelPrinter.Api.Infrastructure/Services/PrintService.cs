using combit.Reporting;
using combit.Reporting.DataProviders;
using ListLabelPrinter.Api.Infrastructure.Services.Abstractions;

namespace ListLabelPrinter.Api.Infrastructure.Services;

public sealed class PrintService : IPrintService
{
    private readonly ListLabel _listLabel;

    public PrintService(ListLabel listLabel)
    {
        _listLabel = listLabel;
    }

    public Task Print(PrintParameters parameters)
    {
        _listLabel.Language = parameters.Language ?? LlLanguage.Default;
        _listLabel.DataSource = new JsonDataProvider(parameters.DataSource.ToString());
        
        if (string.IsNullOrEmpty(parameters.PrinterName))
        {
            _listLabel.Print(parameters.LlProject, parameters.ReportFile);
            return Task.CompletedTask;
        }
        // <ItemGroup>
        //     <Reference Include="System.Drawing.Common, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51" />
        // </ItemGroup>
        //_listLabel.Core.LlSetPrinterInPrinterFile(parameters.LlProject, parameters.ReportFile, parameters.PrinterName);
        _listLabel.Print();
        return Task.CompletedTask;
    }
}