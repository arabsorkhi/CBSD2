using CBSD.Seller.Core.Domain.SellerAgg.Events;
using CBSD.Seller.Core.Domain.SellerAgg.ValueObjects;
using Framework.Domain.Entities;
using Framework.Domain.Events;
using System;
using System.Collections.Generic;

namespace CBSD.Seller.Core.Domain.SellerAgg.Entities
{
    public class Product : BaseEntity<Guid> //AggregateRoot<VehicleId>
                                            
    {
        #region Fields
        public ProductId Id { get; init; }
        public ProductName Name { get; init; }
        public string Description { get; init; }
        public string Title { get; init; }
        public List<Picture> Pictures { get; private set; }

        public int Order { get; private set; }
        #endregion
        public Product( )
        { 
        }
        //double dispatch
        //applier change state by own and notif Root to validate
        public Product(Action<IEvent> applier, ProductId id, ProductName name, string description, string title, List<Picture> pictures) : base(applier)
        {
            Id = id;
            Name = name;
            Description = description;
            Title = title;
            Pictures = pictures;
        }

        #region Methods Domain behaviors

        public void AddPicture(PictureUrl pictureUrl, PictureSize pictureSize)
        {
            var newPic = new Picture(HandleEvent);
            newPic.HandleEvent(new ProductPictureAddedEvent
            {
                Id = Id,
                PictureUrl = pictureUrl,
                Name = Name.Value,
                Height = pictureSize.Height,
                Width = pictureSize.Width,
                Order = Order,
                //PictureSize=pictureSize.Height;


            });

            Pictures.Add(newPic);
        }
        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case ProductPictureAddedEvent e:
                    //    Id =new ProductId(e.Id);
                    //     Pictures = PictureUrl.FromString(e.PictureUrl);
                    //    Size = new PictureSize(e.Height, e.Width);
                    //    Order = e.Order;
                    break;
                    //case AdvertismentPictureResized e:
                    //    Size = new PictureSize(e.Height, e.Width);
                    //    break;
            }
        }

        #endregion
    }
}
