
using VSCodeEventBus.Controllers.Misc;

namespace VSCodeEventBus.CQRS
{
    public interface ICommand
    {

    }
    
    public interface ICommandHandler<T> where T : ICommand
    {
        Result Handle(T command);
    }



}