using System.Runtime.Serialization;

namespace core.Entities.Oders
{
    public enum OrderStatus
    {
        [EnumMember(Value ="Pending")]
        Pending,
        [EnumMember(Value ="Payment received")]
        PaymentReceived,
        [EnumMember(Value ="Payment failed")]
        PaymentFailed
    }
}