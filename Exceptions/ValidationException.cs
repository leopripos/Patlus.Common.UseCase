using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Patlus.Common.UseCase.Exceptions
{
    public class ValidationException : Exception
    {
        public IReadOnlyDictionary<string, string[]> Failures { get; private set; }

        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(IReadOnlyDictionary<string, string[]> failures)
            : base("One or more validation failures have occurred.")
        {
            Failures = failures;
        }

        public ValidationException(IList<ValidationFailure> failures)
        {
            var failuresDictionary = new Dictionary<string, string[]>();

            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                failuresDictionary.Add(propertyName, propertyFailures);
            }

            this.Failures = failuresDictionary;
        }
    }
}
