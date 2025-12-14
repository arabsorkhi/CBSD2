using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Domain.Events;

namespace CBSD.Seller.Core.Domain.SellerAgg.Events
{
    public class SellerSentReceiptEvent : IDomainEvent
    {
        public Guid id { get; set; }

    }
}
