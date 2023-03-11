using FluentValidation;
using ListLabelPrinter.Api.Features.Models;

namespace ListLabelPrinter.Api.Features.Validators
{
    public sealed class PrintRequestValidator : AbstractValidator<PrintRequest>
    {
        private const string InvalidPathMessage = "Invalid file path";
        private const string FileNotFoundMessage = "Report file not found";

        public PrintRequestValidator()
        {
            RuleFor(x => x.ReportFile)
                .NotEmpty()
                .Must(Path.IsPathRooted)
                .WithMessage(InvalidPathMessage)
                .Must(File.Exists)
                .WithMessage(FileNotFoundMessage);

            RuleFor(x => x.DataSource)
                .NotNull();
        }
    }
}