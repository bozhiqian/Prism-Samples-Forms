using System;
using System.Collections.Generic;
using System.Text;
using Prism.Events;

namespace UsingEventAggregator.Models
{
    public class IsFunChangedEvent : PubSubEvent<bool> { }
}
