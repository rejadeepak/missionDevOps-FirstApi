using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace VSCodeEventBus.VSCodeEventBus
{
    public interface ISubscriptionManager
    {
        void AddSubscription(string eventName, Type integartionEventType);
        List<SubscriptionInfo> GetSubscription(string eventName);
    }

    public class SubscriptionManager : ISubscriptionManager
    {

        private readonly Dictionary<string, List<SubscriptionInfo>> subscriptionDictionary;
       
        public SubscriptionManager()
        {
            subscriptionDictionary = new Dictionary<string, List<SubscriptionInfo>>();
           
        }


        public void AddSubscription(string eventName, Type integartionEventType)
        {
            if (integartionEventType == null)
                return;            
                
            if (subscriptionDictionary.Keys.Any(x => x.Equals(eventName, StringComparison.CurrentCultureIgnoreCase)))
            {
                var subscriptionInfos = subscriptionDictionary.GetValueOrDefault(eventName);

                if (!subscriptionInfos.Any(x=>x.EventHandlerType.Equals(integartionEventType)))
                    subscriptionInfos.Add(SubscriptionInfo.Add(integartionEventType));
                
            }
            else{
                subscriptionDictionary.Add(eventName, new List<SubscriptionInfo>());
                    var subscriptionInfos = subscriptionDictionary.GetValueOrDefault(eventName);
                    subscriptionInfos.Add(SubscriptionInfo.Add(integartionEventType));
            }
        }

        public List<SubscriptionInfo> GetSubscription(string eventName){
            subscriptionDictionary.TryGetValue(@eventName, out List<SubscriptionInfo> subscriptionInfos);
            return subscriptionInfos;
        }
        

    }
}
