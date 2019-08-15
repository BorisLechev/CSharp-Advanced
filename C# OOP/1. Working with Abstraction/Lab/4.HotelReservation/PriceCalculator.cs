using System;
using System.Collections.Generic;
using System.Text;

namespace _4.HotelReservation
{
    public class PriceCalculator
    {
        public decimal Calculate(decimal pricePerDay, int numberOfDays, Season season, DiscountType discountType)
        {
            int multiplier = (int)season;
            decimal discount = (decimal)discountType / 100;

            decimal priceBeforDiscount = pricePerDay * multiplier * numberOfDays;
            decimal totalPrice = priceBeforDiscount * (1 - discount);

            return totalPrice;
        }
    }
}
