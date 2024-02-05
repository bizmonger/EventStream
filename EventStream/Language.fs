namespace EventStream

open System

module Language =

    type Bounty = decimal

    [<CLIMutable>]
    type Coordinate = {
        Latitude  : double
        Longitude : double
    }

    [<CLIMutable>]
    type Customer = {
        CustomerId : string
        Name       : string
        Location   : Coordinate
        Phone      : string
    }

    [<CLIMutable>]
    type Cost = { 
        Amount : decimal
        Unit   : string 
    }

    [<CLIMutable>]
    type Item = {
        ItemId : string
        Name   : string
        Image  : string
        CategoryId : int
        SubcategoryId : int
        Description   : string
        Weight : decimal
        Price  : Cost
    }

    [<CLIMutable>]
    type ItemQty = {
        Item : Item
        Qty  : int
    }

    [<CLIMutable>]
    type ItemQtys = ItemQty seq

    [<CLIMutable>]
    type Request = {
        RequestId : Guid
        Customer  : Customer
        Items     : ItemQty seq
        Timestamp : DateTime
    }

    [<CLIMutable>]
    type CarrierProfile = {
        CarrierId : string
        Name : string
        CarrierType : string
        Description : string
        Image : string
    }

    [<CLIMutable>]
    type ItemsLocation = {
        Items    : ItemQtys
        Location : Coordinate
    }

    [<CLIMutable>]
    type Pickup = {
        Name  : string
        Image : string
        ItemsLocation : ItemsLocation
    }

    [<CLIMutable>]
    type Carrier = {
        CarrierProfile : CarrierProfile
        Pickup : Pickup
    }

    [<CLIMutable>]
    type Carriers = Carrier seq

    [<CLIMutable>]
    type Quote = {
        Request  : Request
        Price    : Cost
        Carriers : Carriers
        Deposit  : decimal
    }

    [<CLIMutable>]
    type Order = {
        Quote     : Quote
        Pickups   : Carriers
        Dropoff   : Coordinate
        Bounty    : Bounty
        Timestamp : DateTime
    }

    type Connection = {
        ConnectionString : string
        HubName : string
    }