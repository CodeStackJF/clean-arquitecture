﻿using System.IO.Compression;
using FluentValidation.Results;

namespace Application.Exceptions
{
    public class CustomValidationException : Exception
    {
        public Dictionary<string, List<string>> Errors { get; } = new Dictionary<string, List<string>>();

        public CustomValidationException() : base("Se han producido errores de validación.")
        { 

        }

        public CustomValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            var registers = failures.GroupBy(x=>x.PropertyName).Select(x=>new {
                PropertyName = x.Key,
                Errors = x.Select(y=>y.ErrorMessage).ToList()
            });

            foreach(var register in registers)
            {
                Errors.Add(register.PropertyName, register.Errors);
            }
        }

        public CustomValidationException(string property, string message)
        {
            Errors.Add(property, new List<string>(){message});
        }
    }
}
