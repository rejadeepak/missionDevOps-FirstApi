
using VSCodeEventBus.CQRS;
using VSCodeEventBus.Domain;

namespace VSCodeEventBus.Mapper
{
    public interface IOrderMapper
    {
        Order Map(OrderCommand order);

    }
}