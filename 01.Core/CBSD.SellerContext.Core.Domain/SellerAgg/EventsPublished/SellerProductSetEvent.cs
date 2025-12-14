    using Framework.Domain.Events;
using System;

namespace CBSD.Seller.Core.Domain.SellerAgg.Events
{
    public class SellerProductSetEvent : IDomainEvent
    {
        public Guid ProductId { get; set; }

    }
}
