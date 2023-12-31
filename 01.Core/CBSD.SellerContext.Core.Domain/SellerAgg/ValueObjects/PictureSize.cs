﻿using Framework.Domain.ValueObject;
using System;

namespace CBSD.Seller.Core.Domain.SellerAgg.ValueObjects
{
    public class PictureSize : BaseValueObject<PictureSize>
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        private PictureSize()
        {

        }
        public PictureSize(int width, int height)
        {
            if (Width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), "عرض تصویر باید عددی مثبت باشد.");
            if (Height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), "ارتفاع تصویر باید عددی مثبت باشد");
            Width = width;
            Height = height;
        }
        public override int ObjectGetHashCode()
        {
            return (Width + Height).GetHashCode();
        }

        public override bool ObjectIsEqual(PictureSize otherObject)
        {
            return Height == otherObject.Height && Width == otherObject.Width;
        }
    }
}
