using CBSD.Seller.Core.Domain.SellerAgg.Events;
using CBSD.Seller.Core.Domain.SellerAgg.ValueObjects;
using Framework.Domain.Entities;
using Framework.Domain.Events;
using System;

namespace CBSD.Seller.Core.Domain.SellerAgg.Entities
{
    public class Picture : BaseEntity<Guid>
    {
        #region Fields
        public PictureSize Size { get; private set; }
        public PictureUrl Location { get; private set; }
        public int Order { get; private set; }
        #endregion

        #region Constructors
        private Picture()
        {

        }
        public Picture(Action<IEvent> applier) : base(applier)
        {
        }
        #endregion

        #region Methods
        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case ProductPictureAddedEvent e:
                    Id = e.Id;
                    Location = PictureUrl.FromString(e.PictureUrl);
                    Size = new PictureSize(e.Height, e.Width);
                    Order = e.Order;
                    break;
                    //case AdvertismentPictureResized e:
                    //    Size = new PictureSize(e.Height, e.Width);
                    //    break;
            }
        }
        //public void Resize(PictureSize newSize)
        //{
        //    SetStateByEvent(new AdvertismentPictureResized
        //    {
        //        PictureId = Id,
        //        Height = newSize.Width,
        //        Width = newSize.Width
        //    });
        //}
        #endregion
    }
}
