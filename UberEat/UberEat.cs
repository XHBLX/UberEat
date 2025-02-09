﻿using System;
namespace UberEat
{
    public class UberEat
    {
        IClient _Client;
        IAvaibleBusinessProviders _AvailableRestaurants;
        IBusinessProvider _RestaurantSelected;
        IShippableOrder _Order;

        public UberEat()
        {   
            //_Client = logged in user //Do I need to show how to implemetn this?..
            _AvailableRestaurants.UpdateAvailableProviders();
        }

        public void SelectRestaurant(IBusinessProvider RestaurantSelected)
        {
            _RestaurantSelected = RestaurantSelected;
        }

        public void AddFoodToOrder(IPurchasable food  )
        {
            _Order.AddPurchased(food);
        }

        public bool HandleOrder()
        {
            /*Not sure about whether I need this line or not, I think the software need to
            wait for restaurant to accept order, assuming the frontend calls this
            HandleOrder() in a while loop or other possible proper ways. */
            if (!_RestaurantSelected.OrderAccepted(_Order))
                return false;
            _Client.PayForOrder(_Order, _RestaurantSelected);
            _RestaurantSelected.AskProviderToDeliverOrderedGoods(_Order, _Client);
            _Order.clear();
            return true;
        }
    }
}
