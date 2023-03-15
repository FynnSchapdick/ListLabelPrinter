namespace ListLabelPrinter.Core.Domain;

public sealed record Template
{
    public Template(string fileName, byte[] data)
    {
        FileName = fileName;
        Data = data;
    }

    public Guid TemplateId { get; init; } = Guid.NewGuid();
    public string FileName { get; init; } = string.Empty;
    public byte[] Data { get; init; } = Array.Empty<byte>();
    public DateTime UpdatedAt { get; init; } = DateTime.Now;
}