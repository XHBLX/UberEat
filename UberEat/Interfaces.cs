﻿using System;
namespace UberEat
{   
    /* Reuse: any payment, in any currency*/
    public interface IPayment
    {

    }

    /*Reuse: any location, can be address, or a temporary location of an object.*/
    public interface ILocation
    {

    }

    /*Reuse: IPurchasable can be any good or services(ex: booking hotel, goods from grocery stores..) that can be purchased */
    public interface IPurchasable
    {
        IPayment Price { get; }
        IBusinessProvider OrderProvider { get; }
    }

    /*Reuse: an order containing one or more than one 'any kind of good or services 
      from the same seller. */
    public interface IOrder
    {
        void AddPurchased(IPurchasable ToBePurchased);
        IPayment Price { get; }
        IBusinessProvider OrderProvider { get; }
        void clear();
    }

    /* Reuse: IOrderPlacable represents any client ordering any good or services */
    public interface IOrderPlacable
    {
        void PlaceOrder(IOrder order, IOrderReceivable orderReceiver);
    }

    /*Reuse: Any organization, individual providing good or services clients require*/
    public interface IOrderReceivable
    {
        bool OrderAccepted(IOrder order);
    }

    /* Reuse: IOrderPlacable represents any client paying for any good or services */
    public interface IPayable
    {
        void PayForOrder(IOrder order, IPaymentRecievable seller);
    }

    /* Reused: any good or service provider receiving payment */
    public interface IPaymentRecievable
    {
        void AcceptPayment(IPayment payment);
    }


    /* Reuse: Location can be address or current location of any moving object*/
    public interface ILocationProvidable
    {
        ILocation Location { get; }
    }

    /* Reuse: Any goods that can be shipped */
    public interface IShippable
    {
        /*Should I create another interface that's responsible to ship stuffs?*/
        ILocation Location { get; }
        //void ShipTo(ILocation target); commented out, I don't think I need it, but not sure.
    }

    /* Reuse: Any group of shippable goods from a same seller */
    public interface IShippableOrder: IOrder, IShippable
    {

    }

    /* Reuse: any client buying goods, and need the goods to be delivered. */
    public interface IClient: IOrderPlacable, IPayable, ILocationProvidable
    {

    }

    /*  Reuse: any good provider that need to deliver goods to client*/
    public interface IBusinessProvider: IOrderReceivable, IPaymentRecievable, ILocationProvidable
    {

        void AskProviderToDeliverOrderedGoods(IShippable order, IClient client );
    }

    /* Reuse: A collection of good or service providers that can be displayed on a software,
     they provide some type of good or service: food, booking rooms, online groceries etc.  */
    public interface IAvaibleBusinessProviders
    {
        void UpdateAvailableProviders();
        void DisplayProviders();
    }


}
