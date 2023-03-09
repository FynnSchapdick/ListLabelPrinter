using System.Net;
using FluentAssertions;
using ListLabelPrint.HttpClient.Requests;

namespace ListLabelPrinter.Api.IntegrationTests.EndpointTests;

public sealed class PrintEndpointTests : IClassFixture<ListLabelPrinterApiFactory>
{
    private readonly IListLabelPrintClient _client;
    
    public PrintEndpointTests(ListLabelPrinterApiFactory apiFactory)
    {
        _client = RestService.For<IListLabelPrintClient>(apiFactory.CreateClient());
    }
    
    [Fact]
    public async Task Create_ReturnsBadRequest_WhenRequestIsNotValid()
    {
        IApiResponse response = await _client.Print(new PrintRequest("", new { }));
        response.Should().NotBeNull();
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
}