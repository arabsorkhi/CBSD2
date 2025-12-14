using Framework.Domain.Events;
using System;

namespace CBSD.Seller.Core.Domain.SellerAgg.Events
{
    public class SellerCreatedEvent : IDomainEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
