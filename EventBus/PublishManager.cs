using System.Collections.Concurrent;
using Newtonsoft.Json;
using System;


namespace VSCodeEventBus.VSCodeEventBus
{
    public interface IPublishManager
    {
        void publish(IntergrationEvent @event);
        //TODO Remove
        Message ReadMessage();
    }


    public class PublishManager : IPublishManager
    {
        private readonly BlockingCollection<Message> collection;
        public PublishManager()
        {
            collection = new BlockingCollection<Message>();
        }
        public void publish(IntergrationEvent @event)
        {
            if (@event == null)
                return;

            string body = JsonConvert.SerializeObject(@event);

            Message message = new Message()
            {
                MessageId = Guid.NewGuid(),
                Body = body,
                Label = @event.GetType().Name,
                EventType=@event.GetType().ToString()
                
            };

            collection.Add(message);
        }

         //TODO Remove
        public Message ReadMessage(){            
             collection.TryTake(out Message message);        
             return message;
        }

       

    }
}