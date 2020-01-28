using System;

namespace Patlus.Common.UseCase.Exceptions
{
    public class OperationNotAllowedException : InvalidOperationException
    {
        public OperationNotAllowedException(string message) : base(message)
        { }
    }
}
