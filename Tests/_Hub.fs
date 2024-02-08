module Tests

open System.Configuration
open NUnit.Framework
open EventStream.Language
open EventStream.DataGateway
open EventStream.TestAPI.Mock

[<Test>]
let ``publish event`` () =

    task {

        // Setup
        let hubConnectionString     = ConfigurationManager.AppSettings["hubConnectionString"]
        let storageConnectionString = ConfigurationManager.AppSettings["storageConnectionString"]

        let connection : Connection = {
            StorageConnectionString = storageConnectionString
            StorageContainer = "orders"

            HubConnectionString = hubConnectionString
            HubName = "OrdersHub"
        }

        match! connection |> Bootstrap.eventHub with
        | Error msg -> Assert.Fail msg
        | Ok _ ->

            // Test
            match! connection |> Publish.status someOrder with
            | Error msg -> Assert.Fail msg
            | Ok _      -> Assert.Pass()
    }