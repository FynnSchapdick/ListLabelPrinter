using FluentValidation;
using ListLabelPrinter.Api.Features.Models;

namespace ListLabelPrinter.Api.Features.Validators;

public sealed class PrintRequestValidator : AbstractValidator<PrintRequest>
{
    public PrintRequestValidator()
    {
        RuleFor(x => x.ReportFile)
            .NotEmpty();
        
        RuleFor(x => x.DataSource)
            .NotNull();
    }
}