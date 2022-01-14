using static Core.Enums.Enums;

namespace Core.Specefication
{
    public class Order
    {
        public Order(string propertyName, OrderTypeEnum orderType)
        {
            PropertyName = propertyName;
            OrderType = orderType;
        }

        public string PropertyName { get; set; }
        public OrderTypeEnum OrderType { get; set; }

    }
}