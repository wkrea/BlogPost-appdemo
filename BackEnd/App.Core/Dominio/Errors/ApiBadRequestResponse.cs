using System;
using System.Collections.Generic;
using System.Linq;
using App.Core.Dominio.Errors;
using Microsoft.AspNetCore.Mvc.ModelBinding;

public class ApiBadRequestResponse : ErrorBase
{
    public IEnumerable<string> Errores { get; }
    public ApiBadRequestResponse(ModelStateDictionary modelState) : base(400)
    {
        if (modelState.IsValid)
        {
            throw new ArgumentException("Los datos suministrados no parecen válidos", nameof(modelState));
        }

        Errores = modelState
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToArray();
    }
}