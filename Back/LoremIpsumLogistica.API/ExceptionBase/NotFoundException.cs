using System.Net;

namespace LoremIpsumLogistica.API.ExceptionBase;

public class NotFoundException : LoremIpsumLogisticaException
{
    public NotFoundException(string message) : base(message)
    {
    }

    public override IList<string> GetErrorMessages() => [Message];

    public override HttpStatusCode GetStatusCode() => HttpStatusCode.NotFound;
}
