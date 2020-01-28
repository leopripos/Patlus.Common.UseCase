using MediatR;
using System;

namespace Patlus.Common.UseCase
{
    public interface IFeatureNotification : INotification
    {
        DateTimeOffset Time { get; }
    }
}
