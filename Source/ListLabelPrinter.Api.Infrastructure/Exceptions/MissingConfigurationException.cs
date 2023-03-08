using System.Runtime.Serialization;

namespace ListLabelPrinter.Api.Infrastructure.Exceptions;

[Serializable]
public sealed class MissingRequiredConfigurationException : Exception
{
    public MissingRequiredConfigurationException(string key) : base($"Missing Required Configuration for Paramater {key}.")
    {
    }

    private MissingRequiredConfigurationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}