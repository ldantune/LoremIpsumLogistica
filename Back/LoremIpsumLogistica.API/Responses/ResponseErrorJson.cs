namespace LoremIpsumLogistica.API.Responses;

public class ResponseErrorJson
{
    public IList<string> Errors { get; set; }
    public ResponseErrorJson(IList<string> errors) => Errors = errors;
    public ResponseErrorJson(string errors)
    {
        Errors = [errors];
    }
}
