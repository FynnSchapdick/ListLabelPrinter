using ListLabelPrint.HttpClient.Requests;
using Refit;

namespace ListLabelPrint.HttpClient.Abstractions;

public interface IListLabelPrintClient
{    
    [Post("/print")]
    Task<IApiResponse> Print([Body] PrintRequest request);
}