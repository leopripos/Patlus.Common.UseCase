using System;

namespace Patlus.Common.UseCase.Services
{
    public class TimeService : ITimeService
    {
        public DateTimeOffset Now
        {
            get { return DateTimeOffset.UtcNow; }
        }

        public DateTime NowDateTime
        {
            get { return DateTime.UtcNow; }
        }
    }
}
