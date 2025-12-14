using Framework.Domain.Events;
using System;

namespace CBSD.Seller.Core.Domain.SellerAgg.Events
{
    public class ProductPictureAddedEvent : IDomainEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string PictureUrl { get; set; }
        public string PictureSize { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Order { get; set; }
    }
}
