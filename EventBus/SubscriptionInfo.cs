using System;

namespace VSCodeEventBus.VSCodeEventBus
{
    //TODO :Need to add Interface
    public class SubscriptionInfo
    {
        public Type EventHandlerType { get; }       
        private SubscriptionInfo(Type eventHandlerType)
        {
            EventHandlerType = eventHandlerType;
        }

        public static SubscriptionInfo Add(Type eventHandlerType)
        {
            return new SubscriptionInfo(eventHandlerType);
        }

    }

}