using combit.Reporting;
using combit.Reporting.DataProviders;
using ListLabelPrinter.Infrastructure.Services.Printing.Abstractions;

namespace ListLabelPrinter.Infrastructure.Services.Printing;

public sealed class LlPrinter : IPrinter
{
    private readonly ListLabel _listLabel;

    public LlPrinter(ListLabel listLabel)
    {
        _listLabel = listLabel;
    }

    public void Print()
    {
        _listLabel.Print();
    }

    public ObjectDataProvider? DataSource
    {
        get => _listLabel.DataSource as ObjectDataProvider;
        set => _listLabel.DataSource = value;
    }
    
    public LlLanguage Language
    {
        get => _listLabel.Language;
        set => _listLabel.Language = value;
    }
    
    public bool Printerless
    {
        get => _listLabel.Printerless;
        set => _listLabel.Printerless = value;
    }

    public string AutoProjectFile
    {
        get => _listLabel.AutoProjectFile;
        set => _listLabel.AutoProjectFile = value;
    }

    public LlProject AutoProjectType
    {
        get => _listLabel.AutoProjectType;
        set => _listLabel.AutoProjectType = value;
    }
}