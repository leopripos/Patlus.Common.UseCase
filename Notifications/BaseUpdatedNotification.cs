using System;
using System.Collections.Generic;

namespace Patlus.Common.UseCase.Notifications
{
    public abstract class BaseUpdatedNotification<TEntity> : IFeatureNotification
    {
        public TEntity Entity { get; set; }
        public Dictionary<string, ValueChanged> Values { get; set; }

        public Guid By { get; set; }
        public DateTime Time { get; set; }
    }

    public class ValueChanged
    {
        public object Old { get; set; }
        public object New { get; set; }
    }
}
