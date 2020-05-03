using System;
namespace VSCodeEventBus.VSCodeEventBus
{
    public abstract class IntergrationEvent
    {       
        public Guid Id { get; } = Guid.NewGuid(); 
        public DateTime CreationDate { get;  }= DateTime.UtcNow;
    }
    public interface IIntergrationEventHandler<T> where T : IntergrationEvent
    {
        void Handle(T intergationEvent);
    }

}