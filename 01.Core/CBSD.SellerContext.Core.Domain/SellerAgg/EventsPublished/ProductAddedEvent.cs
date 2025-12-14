using Framework.Domain.Events;
using System;

namespace CBSD.Seller.Core.Domain.SellerAgg.Events
{
    //domain Event
    public class ProductAddedevent : IDomainEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }

    }
}
