using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoremIpsumLogistica.API.ExceptionBase;
using LoremIpsumLogistica.API.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LoremIpsumLogistica.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is LoremIpsumLogisticaException loremIpsumLogisticaException)
            HandleProjectException(loremIpsumLogisticaException, context);
        else
            ThrowUnknowException(context);
    }

    private static void HandleProjectException(LoremIpsumLogisticaException loremIpsumLogisticaException, ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)loremIpsumLogisticaException.GetStatusCode();
        context.Result = new ObjectResult(new ResponseErrorJson(loremIpsumLogisticaException.GetErrorMessages()));
    }

    private static void ThrowUnknowException(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorJson(context.Exception.Message));
    }
}
