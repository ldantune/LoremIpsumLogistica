using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
