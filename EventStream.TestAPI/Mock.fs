namespace EventStream.TestAPI

open System
open EventStream.Language

module Mock =

        let someCustomer : Customer = {
            CustomerId = "some customer id"
            Name       = "some name"
            Location   = { Latitude= 0.0; Longitude= 0.0}
            Phone      = "555.555.5555"
        }

        let someItem : Item = {
            ItemId = "some id"
            Name   = "some name"
            Image  = "some image"
            CategoryId = 0
            SubcategoryId = 0
            Description   = "some desc"
            Weight = 0m
            Price  = { Amount= 0m; Unit="unit"}
        }

        let someItemQty : ItemQty = {
            Item = someItem
            Qty  = 0
        }

        let someRequest : Request = {
            RequestId = Guid.NewGuid()
            Customer  = someCustomer
            Items     = [someItemQty]
            Timestamp = DateTime.Now
        }

        let someQuote : Quote = {
            Request  = someRequest
            Price    = { Amount= 9m; Unit= ""}
            Carriers = []
            Deposit  = 0m
        }

        let someOrder : Order = {
            Quote     = someQuote
            Pickups   = []
            Dropoff   = { Latitude=0.0; Longitude=0.0 }
            Bounty    = 5m
            Timestamp = DateTime.Now
        }