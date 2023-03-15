using combit.Reporting;
using combit.Reporting.DataProviders;
using ListLabelPrinter.Infrastructure.Services.Printing;
using ListLabelPrinter.Infrastructure.Services.Printing.Abstractions;
using Moq;

namespace ListLabelPrinter.Infrastructure.UnitTests.Services;

public class PrinterServiceTests
{
    [Fact]
    public async Task Print_Should_Call_Printer_Print_With_Correct_Parameters()
    {
        // Arrange
        Mock<IPrinter> printerMock = new Mock<IPrinter>();
        PrintService printService = new PrintService(printerMock.Object);
        string path = Path.Combine("Reports", "Zweispaltige Artikelliste.lst");
        PrintParameters parameters = new PrintParameters(path, new { }, printerless: true);
        
        // Act
        await printService.Print(parameters);

        // Assert
        printerMock.Verify(ll => ll.Print(), Times.Once);
        printerMock.VerifySet(ll => ll.DataSource = It.IsAny<ObjectDataProvider>(), Times.Once);
        printerMock.VerifySet(ll => ll.Printerless = It.IsAny<bool>(), Times.Once);
        printerMock.VerifySet(ll => ll.AutoProjectType = It.IsAny<LlProject>(), Times.Once);
        printerMock.VerifySet(ll => ll.AutoProjectFile = It.IsAny<string>(), Times.Once);
        printerMock.VerifySet(ll => ll.Language = It.IsAny<LlLanguage>(), Times.Once);
        printerMock.VerifyNoOtherCalls();
    }
}