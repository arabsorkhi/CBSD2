using Framework.Domain.Events;
using System;

namespace CBSD.Seller.Core.Domain.SellerAgg.Events
{
    public class SellerPriceSetEvent : IDomainEvent
    {
        public Guid Id { get; set; }
        public long Price { get; set; }

    }
}
