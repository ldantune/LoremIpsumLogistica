using System.Net;

namespace LoremIpsumLogistica.API.ExceptionBase;

public abstract class LoremIpsumLogisticaException : SystemException
{
    public LoremIpsumLogisticaException(string message) : base(message) { }

    public abstract IList<string> GetErrorMessages();
    public abstract HttpStatusCode GetStatusCode();
}
