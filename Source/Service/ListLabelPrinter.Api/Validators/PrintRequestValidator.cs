using FluentValidation;
using ListLabelPrinter.Api.Contracts;

namespace ListLabelPrinter.Api.Validators
{
    public sealed class PrintRequestValidator : AbstractValidator<CreatePrintJobRequest>
    {
        public PrintRequestValidator()
        {
            RuleFor(x => x.TemplateId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataSource)
                .NotNull();
        }
    }
}