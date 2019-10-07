using System;

namespace Patlus.Common.UseCase.Services
{
    public class TimeService : ITimeService
    {
        public DateTime Now
        {
            get { return DateTime.UtcNow; }
        }
    }
}
