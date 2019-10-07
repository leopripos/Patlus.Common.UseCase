using System;

namespace Patlus.Common.UseCase.Services
{
    public interface ITimeService
    {
        DateTime Now { get; }
    }
}
