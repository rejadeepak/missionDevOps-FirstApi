using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace VSCodeEventBus.VSCodeEventBus
{

    public interface IPubSubEventBus
    {
        void Publish(IntergrationEvent @event);
        void Subscribe<IEvent, IEventHandler>() where IEvent : IntergrationEvent
                                                where IEventHandler : IIntergrationEventHandler<IEvent>;
    }
    public class PubSubEventBus : IPubSubEventBus
    {

        private readonly ISubscriptionManager _subscriptionManager;
        private readonly IPublishManager _publishManager;
        public PubSubEventBus(ISubscriptionManager subscriptionManager, IPublishManager publishManager)
        {
            _subscriptionManager = subscriptionManager;
            _publishManager = publishManager;
        }

        public void Publish(IntergrationEvent @event)
        {
            _publishManager.publish(@event);
        }



        public void Subscribe<IEvent, IEventHandler>()
                                                where IEvent : IntergrationEvent
                                                where IEventHandler : IIntergrationEventHandler<IEvent>
        {
            var eventName = typeof(IEvent).Name;
            _subscriptionManager.AddSubscription(eventName, typeof(IEventHandler));

        }
        
    }

}


//Map Reduce
//Data Structure
//Paraller Programming
