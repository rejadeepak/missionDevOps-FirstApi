

using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VSCodeEventBus.VSCodeEventBus
{
    public interface IProcessManager
    {
        void ProcessEvent(Message message);
    }
    public class ProcessManager : IProcessManager
    {

        private readonly ISubscriptionManager _subscriptionManager;
        private readonly IServiceProvider _provider;
        public ProcessManager(ISubscriptionManager subscriptionManager, IServiceProvider provider)
        {
            _subscriptionManager = subscriptionManager;
            _provider = provider;
        }
        public void ProcessEvent(Message message)
        {
            var subscriptionInfos = _subscriptionManager.GetSubscription(message.Label);
            if (subscriptionInfos == null)
            {
                return;
            }
                Parallel.ForEach(subscriptionInfos, (subscriptionInfo) =>
                {
                    var eventHandler = subscriptionInfo.EventHandlerType;
                    var handler = _provider.GetService(eventHandler);
                    var eventType = Type.GetType(message.EventType);
                    var integrationEvent = JsonConvert.DeserializeObject(message.Body, eventType);
                    var unboundEventHandlerType = typeof(IIntergrationEventHandler<>);
                    var concreteType = unboundEventHandlerType.MakeGenericType(eventType);
                    concreteType.GetMethod("Handle").Invoke(handler, new object[] { integrationEvent });// TODO: Need to Tested..
                });
            
        }
    }
}