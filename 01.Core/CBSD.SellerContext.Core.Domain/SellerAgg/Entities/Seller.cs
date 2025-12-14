using CBSD.Seller.Core.Domain.SellerAgg.Events;
using CBSD.Seller.Core.Domain.SellerAgg.ValueObjects;
using Framework.Domain.Entities;
using Framework.Domain.Events;
using Framework.Domain.Exceptions;
using Framwork.Tools.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CBSD.Seller.Core.Domain.SellerAgg.Entities
{


    public sealed class Seller : BaseAggregateRoot<Guid>
    {
        #region vo

        public Price Price { get; private set; }
        public List<Product> Products { get; private set; }
        public SellerStatus Status { get; private set; }
        public NameVO Name { get; internal set; }
        public AddressVO Address { get; internal set; }

        #endregion

        //behaviure: create
        public Seller(UserId id, NameVO sellerName, AddressVO address)
        {
            Products = new List<Product>();

            HandleEvent(new SellerCreatedEvent { Id = id, Address = address.FullAddress, Name = sellerName.Value });
        }

        //query


        //root:command->event
        public void SetPrice(Price price, Guid guid)
        {

            HandleEvent(new SellerPriceSetEvent { Id = guid, Price = price.Value });
        }

        public void SetProduct(Guid productId)
        {
            HandleEvent(new SellerProductSetEvent { ProductId = productId });
        }

        public void SendReceipt(Guid id)
        {

            HandleEvent(new SellerSentReceiptEvent { id = id });
        }

        #region product
        //nested it needs picture
        public void AddProduct()
        {
            //agg create entity instance
            var newProduct = new Product();

            //agg  create and publish event
            newProduct.HandleEvent(new ProductAddedevent
            {
                Description = newProduct.Description,
                Id = newProduct.Id,
                Name = Name.Value,

            });

            Products.Add(newProduct);

        }


        #endregion



        protected override void SetStateByEvent(IEvent @event)
        {
            switch (@event)
            {
                case SellerCreatedEvent e:
                    Id = e.Id;
                    Name = NameVO.Create(e.Name);
                    Status = SellerStatus.New;
                    break;
                case SellerPriceSetEvent e:
                    Price = new Price(Rial.FromLong(e.Price));
                    break;
                case SellerProductSetEvent e:
                    Status = SellerStatus.RequestforSelling;

                    break;
                case SellerSentReceiptEvent e:
                    Status = SellerStatus.Sold;
                    break;
                case ProductAddedevent e:
                    Id = e.Id;
                    break;
                case ProductPictureAddedEvent e:
                    Status = SellerStatus.Edit;
                    break;
                default:
                    throw new InvalidOperationException("امکان اجرای عملیات درخواستی وجود ندارد");
            }
        }

        //validation
        protected override void ValidateInvariants()
        {

            var isValid =
                Id != null &&
                Status switch
                {
                    SellerStatus.New =>
                        Name != null
                        && Price != null,
                    SellerStatus.selling =>
                        Name != null
                        && Price != null
                        ,

                    _ => true
                };
            if (!isValid)
            {
                throw new InvalidEntityStateException(this, $"مقدار تنظیم شده برای آگهی در وضیعت {Status.GetDescription()} غیر قابل قبول است");
            }
        }
    }

    public enum SellerStatus
    {
        [Description("جدید")]
        New = 0,
        Edit = 1,
        Waitting = 4,
        RequestforSelling = 3,
        selling = 2,

        Sold = 5,

    }
}
