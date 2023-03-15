using combit.Reporting;
using combit.Reporting.DataProviders;

namespace ListLabelPrinter.Infrastructure.Services.Printing.Abstractions;

public interface IPrinter
{
    void Print();
    ObjectDataProvider? DataSource { get; set; }
    LlLanguage Language { get; set; }
    bool Printerless { get; set; }
    string AutoProjectFile { get; set; }
    LlProject AutoProjectType { get; set; }
}